using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ISB.CLWater.Service.Services
{
    public class PersonService : ServiceBase
    {
        public PersonService(IConfiguration configuration) : base(configuration)
        {
        }

        private void UpdatePerson(int editUserId, Person person)
        {
            using (SqlConnection connection = CreateConnection())
            {
                SqlCommand command = new SqlCommand("spUpdatePerson", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@p_person_id", person.PersonId);
                command.Parameters.AddWithValue("@p_last_name", person.LastName);
                command.Parameters.AddWithValue("@p_first_name", person.FirstName);
                command.Parameters.AddWithValue("@p_middle_name", CspNothing(person.MiddleInitial));
                command.Parameters.AddWithValue("@p_varstatus", CspNothing(person.VarStatus));
                command.Parameters.AddWithValue("@p_email_address", CspNothing(person.EmailAddress));
                command.Parameters.AddWithValue("@p_varstationed", CspNothing(person.VarStationed));
                command.Parameters.AddWithValue("@p_varworked", CspNothing(person.VarWorked));
                command.Parameters.AddWithValue("@p_varreside", CspNothing(person.VarReside));
                command.Parameters.AddWithValue("@p_varnone", CspNothing(person.VarNone));
                command.Parameters.AddWithValue("@p_suffix_id", person.SuffixId == 0 ? DBNull.Value : CipNothing(person.SuffixId));
                command.Parameters.AddWithValue("@p_primary_phone", person.PrimaryPhone);
                command.Parameters.AddWithValue("@p_alternate_phone", CspNothing(person.AlternatePhone));
                command.Parameters.AddWithValue("@p_comments", DBNull.Value);
                command.Parameters.AddWithValue("@p_hear_about_us_id", person.HearAboutUsId == 0 ? DBNull.Value : CipNothing(person.HearAboutUsId));
                command.Parameters.AddWithValue("@p_other_hear_about_us_desc", CspNothing(person.OtherHearAboutUsId));
                command.Parameters.AddWithValue("@p_is_staging", person.IsStaging == null ? 0 : person.IsStaging);
                command.Parameters.AddWithValue("@p_is_primary", person.IsPrimary == null ? 0 : person.IsPrimary);
                command.Parameters.AddWithValue("@p_primary_id", CipNothing(person.PrimaryId));
                command.Parameters.AddWithValue("@p_edited_by", editUserId);
                command.Parameters.AddWithValue("@p_address_note_id", person.AddressNoteId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void UpdateAddress(int editUserId, Address address)
        {
            using (SqlConnection connection = CreateConnection())
            {
                SqlCommand command = new SqlCommand("spUpdateAddress", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@p_person_id", address.PersonId);
                command.Parameters.AddWithValue("@p_city", CspNothing(address.City));
                command.Parameters.AddWithValue("@p_zipcode", CspNothing(address.ZipCode));
                command.Parameters.AddWithValue("@p_edited_by", editUserId);
                command.Parameters.AddWithValue("@p_state_id", CipNothing(address.StateId));
                command.Parameters.AddWithValue("@p_country_id", CipNothing(address.CountryId));
                command.Parameters.AddWithValue("@p_address_2", CspNothing(address.Address2));
                command.Parameters.AddWithValue("@p_address_1", address.Address1);
                command.Parameters.AddWithValue("@p_other_state_desc", CspNothing(address.OtherStateDescription));

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void InsertAddress(int editUserId, Address address)
        {
            using (SqlConnection connection = CreateConnection())
            {
                SqlCommand command = new SqlCommand("spInsertAddress", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@p_person_id", address.PersonId);
                command.Parameters.AddWithValue("@p_city", CspNothing(address.City));
                command.Parameters.AddWithValue("@p_zipcode", CspNothing(address.ZipCode));
                command.Parameters.AddWithValue("@p_created_by", editUserId);
                command.Parameters.AddWithValue("@p_state_id", CipNothing(address.StateId));
                command.Parameters.AddWithValue("@p_country_id", CipNothing(address.CountryId));
                command.Parameters.AddWithValue("@p_address_2", CspNothing(address.Address2));
                command.Parameters.AddWithValue("@p_other_state_desc", CspNothing(address.OtherStateDescription));
                command.Parameters.AddWithValue("@p_address_1", address.Address1);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void ValidateUser(int editUserId, Person person, Address address, Person compPerson = null, Address compAddress = null)
        {
            UpdatePerson(editUserId, person);
            if (person.IsPrimary == 1)
            {
                int addressCount = PersonAddressCount(person.PersonId);
                switch (addressCount)
                {
                    case 1:
                        UpdateAddress(editUserId, address);
                        break;
                    case 0:
                        InsertAddress(editUserId, address);
                        break;
                    default:
                        throw new Exception("Address Check for user " + person.PersonId + " Failed!");
                }
            }
            if (compPerson != null & compAddress != null)
            {
                UpdatePerson(editUserId, compPerson);
                int addressCount = PersonAddressCount(compPerson.PersonId);
                switch (addressCount)
                {
                    case 1:
                        UpdateAddress(editUserId, compAddress);
                        break;
                    case 0:
                        InsertAddress(editUserId, compAddress);
                        break;
                    default:
                        throw new Exception("Address Check for user " + compPerson.PersonId + " Failed!");
                }
            }
        }

        private int PersonAddressCount(int personId)
        {
            using (SqlConnection connection = CreateConnection())
            {
                SqlCommand command = new SqlCommand("spPersonCountAddress", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@p_person_id", personId);

                connection.Open();
                DataSet dataSet = new DataSet();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataSet);
                }

                int count = Convert.ToInt32(dataSet.Tables[0].Rows[0][0] == DBNull.Value ? 0 : dataSet.Tables[0].Rows[0][0]);
                return count;
            }
        }

        public Person RetrievePerson(int personId)
        {
            Person person = new Person();
            using (SqlConnection connection = CreateConnection())
            {
                SqlCommand command = new SqlCommand("spRetrievePerson", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@p_person_id", personId);

                connection.Open();
                DataSet dataSet = new DataSet();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataSet);
                }

                if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    DataRow row = dataSet.Tables[0].Rows[0];
                    person.PersonId = Convert.ToInt32(row["PERSON_ID"] ?? 0);
                    person.LastName = row["LAST_NAME"].ToString();
                    person.MiddleInitial = row["MIDDLE_NAME"].ToString();
                    person.FirstName = row["FIRST_NAME"]?.ToString();
                    person.VarStatus = row["VARSTATUS"]?.ToString();
                    person.EmailAddress = row["EMAIL_ADDRESS"].ToString();
                    person.VarStationed = row["VARSTATIONED"].ToString();
                    person.VarWorked = row["VARWORKED"].ToString();
                    person.VarReside = row["VARRESIDE"].ToString();
                    person.RegistrationTypeId = Convert.ToInt32(row["REGISTRATION_TYPE_ID"] == DBNull.Value ? 0 : row["REGISTRATION_TYPE_ID"]);
                    person.VarNone = row["VARNONE"].ToString();
                    person.SuffixId = Convert.ToInt32(row["SUFFIX_ID"] == DBNull.Value ? 0 : row["SUFFIX_ID"]);
                    person.PrimaryPhone = row["PRIMARY_PHONE"].ToString();
                    person.AlternatePhone = row["ALTERNATE_PHONE"].ToString();
                    person.HearAboutUsId = Convert.ToInt32(row["HEAR_ABOUT_US_ID"] == DBNull.Value ? 0 : row["HEAR_ABOUT_US_ID"]);
                    person.OtherHearAboutUsId = row["OTHER_HEAR_ABOUT_US_DESC"].ToString();
                    person.IsPrimary = Convert.ToInt32(row["IS_PRIMARY"] == DBNull.Value ? 0 : row["IS_PRIMARY"]);
                    person.IsStaging = Convert.ToInt32(row["IS_STAGING"] == DBNull.Value ? 0 : row["IS_STAGING"]);
                    person.PrimaryId = Convert.ToInt32(row["PRIMARY_ID"] == DBNull.Value ? 0 : row["PRIMARY_ID"]);
                    person.AddressNoteId = Convert.ToInt32(row["ADDRESS_NOTE_ID"] == DBNull.Value ? 0 : row["ADDRESS_NOTE_ID"]);
                    person.AddressNoteDate = Convert.ToDateTime(row["ADDRESS_NOTE_DT"] == DBNull.Value ? null : row["ADDRESS_NOTE_DT"]);
                }
                else
                {
                    throw new Exception("Retrieve Person Returned 0 Records");
                }
            }
            return person;
        }

        public List<StageValidationList> ListStageValidationPersons()
        {
            List<StageValidationList> stageValidationLists = new List<StageValidationList>();
            using (SqlConnection connection = CreateConnection())
            {
                SqlCommand command = new SqlCommand("spListStageValidationRecords", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                connection.Open();
                DataSet dataSet = new DataSet();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataSet);
                }

                foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                {
                    StageValidationList person = new StageValidationList
                    {
                        City = dataRow["city"].ToString(),
                        PersonID = Convert.ToString(dataRow["person_id"]),
                        LastName = dataRow["last_name"].ToString(),
                        FirstName = dataRow["first_name"].ToString(),
                        MiddleInitial = dataRow["middle_name"].ToString(),
                        Suffix = dataRow["suffix_desc"].ToString(),
                        State = dataRow["state_desc"].ToString(),
                        ZipCode = dataRow["zipcode"].ToString(),
                        PrimaryPhoneNumber = dataRow["primary_phone"].ToString(),
                        RegistrationType = dataRow["registration_type_desc"].ToString(),
                        TotalRecords = dataRow["total_rows"].ToString()
                    };
                    stageValidationLists.Add(person);
                }
            }

            if (stageValidationLists.Count != 0)
            {
                _listStageValidationPersonsCount = Convert.ToInt32(stageValidationLists[0].TotalRecords);
            }

            return stageValidationLists.OrderByDescending(x => x.PersonID).ToList();
        }

        public List<StageValidationList> ListStageValidationPersons(string lastName, string firstName, string phoneNumber)
        {
            List<StageValidationList> stageValidationLists = ListStageValidationPersons();

            if (!string.IsNullOrEmpty(lastName))
            {
                stageValidationLists = stageValidationLists.Where(x => x.LastName.ToUpper().Contains(lastName.ToUpper())).ToList();
            }

            if (!string.IsNullOrEmpty(firstName))
            {
                stageValidationLists = stageValidationLists.Where(x => x.FirstName.ToUpper().Contains(firstName.ToUpper())).ToList();
            }

            if (!string.IsNullOrEmpty(phoneNumber))
            {
                stageValidationLists = stageValidationLists.Where(x => x.PrimaryPhoneNumber.Contains(phoneNumber)).ToList();
            }

            if (stageValidationLists.Count != 0)
            {
                _listStageValidationPersonsCount = Convert.ToInt32(stageValidationLists[0].TotalRecords);
            }

            return stageValidationLists.OrderByDescending(x => x.PersonID).ToList();
        }

        private static int _listStageValidationPersonsCount = 0;

        public int ListStageValidationPersonsCount()
        {
            return _listStageValidationPersonsCount;
        }

        public void UpdatePersonRecord(int editUserId, Person person, Address address)
        {
            UpdatePerson(editUserId, person);
            int addressCount = PersonAddressCount(person.PersonId);
            switch (addressCount)
            {
                case 1:
                    UpdateAddress(editUserId, address);
                    break;
                case 0:
                    InsertAddress(editUserId, address);
                    break;
                default:
                    throw new Exception("Address Check for user " + person.PersonId + " Failed!");
            }
        }

        private int InsertPerson(Person person, int userId)
        {
            using (SqlConnection connection = CreateConnection())
            {
                SqlCommand command = new SqlCommand("spInsertPerson", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@p_last_name", person.LastName);
                command.Parameters.AddWithValue("@p_first_name", person.FirstName);
                command.Parameters.AddWithValue("@p_middle_name", CspNothing(person.MiddleInitial));
                command.Parameters.AddWithValue("@p_varstatus", CspNothing(person.VarStatus));
                command.Parameters.AddWithValue("@p_email_address", CspNothing(person.EmailAddress));
                command.Parameters.AddWithValue("@p_varstationed", CspNothing(person.VarStationed));
                command.Parameters.AddWithValue("@p_varworked", CspNothing(person.VarWorked));
                command.Parameters.AddWithValue("@p_varreside", CspNothing(person.VarReside));
                command.Parameters.AddWithValue("@p_varnone", CspNothing(person.VarNone));
                command.Parameters.AddWithValue("@p_suffix_id", CipNothing(person.SuffixId));
                command.Parameters.AddWithValue("@p_primary_phone", person.PrimaryPhone);
                command.Parameters.AddWithValue("@p_alternate_phone", CspNothing(person.AlternatePhone));
                command.Parameters.AddWithValue("@p_comments", "");
                command.Parameters.AddWithValue("@p_hear_about_us_id", CipNothing(person.HearAboutUsId));
                command.Parameters.AddWithValue("@p_other_hear_about_us_desc", CspNothing(person.OtherHearAboutUsId));
                command.Parameters.AddWithValue("@p_is_staging", person.IsStaging == null ? 0 : person.IsStaging);
                command.Parameters.AddWithValue("@p_is_primary", person.IsPrimary == null ? 0 : person.IsPrimary);
                command.Parameters.AddWithValue("@p_primary_id", CipNothing(person.PrimaryId));
                command.Parameters.AddWithValue("@p_edited_by", userId);
                command.Parameters.AddWithValue("@p_reg_type_id", person.RegistrationTypeId);

                connection.Open();
                DataSet dataSet = new DataSet();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataSet);
                }

                return dataSet?.Tables[0].Rows.Count > 0 ? Convert.ToInt32(dataSet.Tables[0].Rows[0][0]) : 0;
            }
        }

        public bool IsDuplicate(Person person, Address address)
        {
            using (SqlConnection connection = CreateConnection())
            {
                SqlCommand command = new SqlCommand("spIsDuplicate", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@p_last_name", person.LastName);
                command.Parameters.AddWithValue("@p_first_name", person.FirstName);
                command.Parameters.AddWithValue("@p_suffix_id", CipNothing(person.SuffixId));
                command.Parameters.AddWithValue("@p_primary_phone", person.PrimaryPhone);
                command.Parameters.AddWithValue("@p_city", CspNothing(address.City));
                command.Parameters.AddWithValue("@p_zipcode", CspNothing(address.ZipCode));
                command.Parameters.AddWithValue("@p_state_id", CipNothing(address.StateId));
                command.Parameters.AddWithValue("@p_country_id", CipNothing(address.CountryId));
                command.Parameters.AddWithValue("@p_address_1", address.Address1);
                command.Parameters.AddWithValue("@p_address_2", CspNothing(address.Address2));

                connection.Open();
                DataSet dataSet = new DataSet();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataSet);
                }

                return dataSet?.Tables[0].Rows.Count > 0 && Convert.ToInt32(dataSet.Tables[0].Rows[0][0]) != 0;
            }
        }

        public void InsertCollectionForm(Person person, Address address, int userId, Comment comment)
        {
            address.PersonId = InsertPerson(person, userId);
            InsertAddress(userId, address);
            if (comment != null)
            {
                comment.PersonId = address.PersonId.ToString();
                InsertComment(userId, comment);
            }
        }

        public Address RetrieveAddress(int personId)
        {
            Address address = new Address
            {
                PersonId = personId
            };
            using (SqlConnection connection = CreateConnection())
            {
                SqlCommand command = new SqlCommand("spRetrieveAddress", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@p_person_id", personId);

                connection.Open();
                DataSet dataSet = new DataSet();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataSet);
                }

                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    DataRow row = dataSet.Tables[0].Rows[0];
                    address.AddressId = Convert.ToInt32(row["ADDRESS_ID"] == DBNull.Value ? 0 : row["ADDRESS_ID"]);
                    address.Address1 = row["ADDRESS_1"].ToString();
                    address.Address2 = row["ADDRESS_2"].ToString();
                    address.City = row["CITY"].ToString();
                    address.StateId = Convert.ToInt32(row["STATE_ID"] == DBNull.Value ? 0 : row["STATE_ID"]);
                    address.ZipCode = row["ZIPCODE"].ToString();
                    address.CountryId = Convert.ToInt32(row["COUNTRY_ID"] == DBNull.Value ? 0 : row["COUNTRY_ID"]);
                    address.OtherStateDescription = row["OTHER_STATE_DESC"].ToString();
                }
                else
                {
                    throw new Exception("Retrieve Address Returned 0 Records");
                }
            }
            return address;
        }

        public NotificationCommentCount RetrieveNotificationCommentCount(int personId)
        {
            NotificationCommentCount notificationCommentCount = new NotificationCommentCount();
            using (SqlConnection connection = CreateConnection())
            {
                SqlCommand command = new SqlCommand("spRetrieveCommentNotifCount", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@p_person_id", personId);

                connection.Open();
                DataSet dataSet = new DataSet();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataSet);
                }

                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    DataRow row = dataSet.Tables[0].Rows[0];
                    notificationCommentCount.CommentCount = Convert.ToInt32(row["comment_count"] == DBNull.Value ? 0 : row["comment_count"]);
                    notificationCommentCount.NotificationCount = Convert.ToInt32(row["notification_count"] == DBNull.Value ? 0 : row["notification_count"]);
                }
                else
                {
                    throw new Exception("Retrieve Comment/Notifications Returned 0 Records");
                }
            }
            return notificationCommentCount;
        }

        public List<CompletePerson> RetrieveDuplicates(Person person, Address address)
        {
            List<CompletePerson> completePersons = new List<CompletePerson>();
            using (SqlConnection connection = CreateConnection())
            {
                SqlCommand command = new SqlCommand("spRetrieveDuplicates", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@p_address_1", address.Address1);
                command.Parameters.AddWithValue("@p_address_2", CspNothing(address.Address2));
                command.Parameters.AddWithValue("@p_city", CspNothing(address.City));
                command.Parameters.AddWithValue("@p_state_id", CipNothing(address.StateId));
                command.Parameters.AddWithValue("@p_zipcode", CspNothing(address.ZipCode));
                command.Parameters.AddWithValue("@p_country_id", CipNothing(address.CountryId));
                command.Parameters.AddWithValue("@p_last_name", person.LastName);
                command.Parameters.AddWithValue("@p_first_name", person.FirstName);
                command.Parameters.AddWithValue("@p_person_id", person.PersonId);
                command.Parameters.AddWithValue("@p_primary_phone", CspNothing(person.PrimaryPhone));

                connection.Open();
                DataSet dataSet = new DataSet();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataSet);
                }

                foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                {
                    CompletePerson completePerson = new CompletePerson
                    {
                        PersonID = Convert.ToInt32(dataRow["PERSON_ID"]),
                        LastName = Convert.ToString(dataRow["LAST_NAME"]),
                        FirstName = Convert.ToString(dataRow["FIRST_NAME"]),
                        PrimaryPhone = dataRow["PRIMARY_PHONE"].ToString(),
                        Address1 = Convert.ToString(dataRow["ADDRESS_1"]),
                        Address2 = dataRow["ADDRESS_2"].ToString(),
                        City = Convert.ToString(dataRow["CITY"]),
                        ZipCode = dataRow["ZIPCODE"].ToString()
                    };
                    completePersons.Add(completePerson);
                }
            }
            return completePersons;
        }

        public void InsertComment(int userId, Comment comment)
        {
            using (SqlConnection connection = CreateConnection())
            {
                SqlCommand command = new SqlCommand("spInsertComment", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@p_user_id", userId);
                command.Parameters.AddWithValue("@p_person_id", comment.PersonId);
                command.Parameters.AddWithValue("@p_comment", comment.CommentDesc);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}