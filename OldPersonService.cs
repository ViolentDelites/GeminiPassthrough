using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using clwater_new.Models;
using clwater_new.Models.Grids;

namespace clwater_new.Services
{
    public class PersonService : ServiceBase
    {
        private void UpdatePerson(int editUserId, Person person)
        {
            OleDbCommand oleDbCommand = new OleDbCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "spUpdatePerson"
            };
            oleDbCommand.Parameters.AddWithValue("@p_person_id", person.PersonId);
            oleDbCommand.Parameters.AddWithValue("@p_last_name", person.LastName);
            oleDbCommand.Parameters.AddWithValue("@p_first_name", person.FirstName);
            oleDbCommand.Parameters.AddWithValue("@p_middle_name", CspNothing(person.MiddleInitial));
            oleDbCommand.Parameters.AddWithValue("@p_varstatus", CspNothing(person.VarStatus));
            oleDbCommand.Parameters.AddWithValue("@p_email_address", CspNothing(person.EmailAddress));
            oleDbCommand.Parameters.AddWithValue("@p_varstationed", CspNothing(person.VarStationed));
            oleDbCommand.Parameters.AddWithValue("@p_varworked", CspNothing(person.VarWorked));
            oleDbCommand.Parameters.AddWithValue("@p_varreside", CspNothing(person.VarReside));
            oleDbCommand.Parameters.AddWithValue("@p_varnone", CspNothing(person.VarNone));
            oleDbCommand.Parameters.AddWithValue("@p_suffix_id", person.SuffixId == 0 ? DBNull.Value : CipNothing(person.SuffixId));
            oleDbCommand.Parameters.AddWithValue("@p_primary_phone", person.PrimaryPhone);
            oleDbCommand.Parameters.AddWithValue("@p_alternate_phone", CspNothing(person.AlternatePhone));
            oleDbCommand.Parameters.AddWithValue("@p_comments", DBNull.Value);
            oleDbCommand.Parameters.AddWithValue("@p_hear_about_us_id", person.HearAboutUsId == 0 ? DBNull.Value : CipNothing(person.HearAboutUsId));
            oleDbCommand.Parameters.AddWithValue("@p_other_hear_about_us_desc", CspNothing(person.OtherHearAboutUsId));
            oleDbCommand.Parameters.AddWithValue("@p_is_staging", person.IsStaging == null ? 0 : person.IsStaging);
            oleDbCommand.Parameters.AddWithValue("@p_is_primary", person.IsPrimary == null ? 0 : person.IsPrimary);
            oleDbCommand.Parameters.AddWithValue("@p_primary_id", CipNothing(person.PrimaryId));
            oleDbCommand.Parameters.AddWithValue("@p_edited_by", editUserId);
            oleDbCommand.Parameters.AddWithValue("@p_address_note_id", person.AddressNoteId);
            DataProcess.SqlConnection.ExecuteNonSelectParameterizedQuery(oleDbCommand);
        }

        // ' summary
        // ' Update Address Record
        // ' /summary
        // ' param name="address"Person Address model/param
        // ' param name="conn"Connection to use/param
        // ' param name="trans"Transaction/param
        // ' remarks/remarks
        private void UpdateAddress(int editUserId, Address address)
        {
            OleDbCommand oleDbCommand = new OleDbCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "spUpdateAddress"
            };
            oleDbCommand.Parameters.AddWithValue("@p_person_id", address.PersonId);
            oleDbCommand.Parameters.AddWithValue("@p_city", CspNothing(address.City));
            oleDbCommand.Parameters.AddWithValue("@p_zipcode", CspNothing(address.ZipCode));
            oleDbCommand.Parameters.AddWithValue("@p_edited_by", editUserId);
            oleDbCommand.Parameters.AddWithValue("@p_state_id", CipNothing(address.StateId));
            oleDbCommand.Parameters.AddWithValue("@p_country_id", CipNothing(address.CountryId));
            oleDbCommand.Parameters.AddWithValue("@p_address_2", CspNothing(address.Address2));
            oleDbCommand.Parameters.AddWithValue("@p_address_1", address.Address1);
            oleDbCommand.Parameters.AddWithValue("@p_other_state_desc", CspNothing(address.OtherStateDescription));
            DataProcess.SqlConnection.ExecuteNonSelectParameterizedQuery(oleDbCommand);
        }

        // ' summary
        // ' Insert Person Address into database
        // ' /summary
        // ' param name="editUserID"Edit User Id/param
        // ' param name="address"Address Model/param
        // ' param name="conn"Current Connection/param
        // ' param name="trans"Current Transaction/param
        private void InsertAddress(int editUserId, Address address)
        {
            OleDbCommand oleDbCommand = new OleDbCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "spInsertAddress"
            };
            oleDbCommand.Parameters.AddWithValue("@p_person_id", address.PersonId);
            oleDbCommand.Parameters.AddWithValue("@p_city", CspNothing(address.City));
            oleDbCommand.Parameters.AddWithValue("@p_zipcode", CspNothing(address.ZipCode));
            oleDbCommand.Parameters.AddWithValue("@p_created_by", editUserId);
            oleDbCommand.Parameters.AddWithValue("@p_state_id", CipNothing(address.StateId));
            oleDbCommand.Parameters.AddWithValue("@p_country_id", CipNothing(address.CountryId));
            oleDbCommand.Parameters.AddWithValue("@p_address_2", CspNothing(address.Address2));
            oleDbCommand.Parameters.AddWithValue("@p_other_state_desc", CspNothing(address.OtherStateDescription));
            oleDbCommand.Parameters.AddWithValue("@p_address_1", address.Address1);
            DataProcess.SqlConnection.ExecuteNonSelectParameterizedQuery(oleDbCommand);
        }


        // ' summary
        // ' Validate a user from stage (optionaly compare record as well)
        // ' /summary
        // ' param name="valPerson"Validate person Record from Stage/param
        // ' param name="editUserID"User ID of Call Center Emp/param
        // ' param name="valAddress"Validating Person Address Record from Stage/param
        // ' param name="compPerson"Optional - Compare Person Record Update/param
        // ' param name="compAddress"Optional - Compare Person Address Record Update/param
        // ' remarksOptionals marked as null for logic/remarks
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
            if ((compPerson != null) & (compAddress != null))
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

        // ' summary
        // ' Return # of address in system user is currently mapped to
        // ' /summary
        // ' param name="personID"Person ID to check/param
        // ' param name="conn"Connection to use/param
        // ' returns# Of Address Records User is Mapped too/returns
        private int PersonAddressCount(int personId)
        {
            OleDbCommand oleDbCommand = new OleDbCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "spPersonCountAddress"
            };
            oleDbCommand.Parameters.AddWithValue("@p_person_id", personId);
            DataSet dataSet = DataProcess.SqlConnection.ExecuteSelectParameterizedQuery(oleDbCommand);
            int count = Convert.ToInt32(dataSet.Tables[0].Rows[0][0] == DBNull.Value ? 0 : dataSet.Tables[0].Rows[0][0]);
            return count;
        }

        // ' summary
        // ' Retrieve Person Model
        // ' /summary
        // ' param name="personID"Person ID to retrieve/param
        // ' returnsPerson Model/returns
        public Person RetrievePerson(int personId)
        {
            Person person = new Person();
            OleDbCommand oleDbCommand = new OleDbCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "spRetrievePerson"
            };
            oleDbCommand.Parameters.AddWithValue("@p_person_id", personId);
            DataSet dataSet = DataProcess.SqlConnection.ExecuteSelectParameterizedQuery(oleDbCommand);
            if (dataSet.Tables.Count > 0)
            {
                person.PersonId = Convert.ToInt32(dataSet.Tables[0].Rows[0]["PERSON_ID"] ?? 0);
                person.LastName = dataSet.Tables[0].Rows[0]["LAST_NAME"].ToString();
                person.MiddleInitial = dataSet.Tables[0].Rows[0]["MIDDLE_NAME"].ToString();
                person.FirstName = dataSet.Tables[0].Rows[0]["FIRST_NAME"]?.ToString();
                person.VarStatus = dataSet.Tables[0].Rows[0]["VARSTATUS"]?.ToString();
                person.EmailAddress = dataSet.Tables[0].Rows[0]["EMAIL_ADDRESS"].ToString();
                person.VarStationed = dataSet.Tables[0].Rows[0]["VARSTATIONED"].ToString();
                person.VarWorked = dataSet.Tables[0].Rows[0]["VARWORKED"].ToString();
                person.VarReside = dataSet.Tables[0].Rows[0]["VARRESIDE"].ToString();
                person.RegistrationTypeId = Convert.ToInt32(dataSet.Tables[0].Rows[0]["REGISTRATION_TYPE_ID"] == DBNull.Value ? 0: dataSet.Tables[0].Rows[0]["REGISTRATION_TYPE_ID"]);
                person.VarNone = dataSet.Tables[0].Rows[0]["VARNONE"].ToString();
                person.SuffixId = Convert.ToInt32(dataSet.Tables[0].Rows[0]["SUFFIX_ID"] == DBNull.Value ? 0 : dataSet.Tables[0].Rows[0]["SUFFIX_ID"]);
                person.PrimaryPhone = dataSet.Tables[0].Rows[0]["PRIMARY_PHONE"].ToString();
                person.AlternatePhone = dataSet.Tables[0].Rows[0]["ALTERNATE_PHONE"].ToString();
                person.HearAboutUsId = Convert.ToInt32(dataSet.Tables[0].Rows[0]["HEAR_ABOUT_US_ID"] == DBNull.Value ? 0 : dataSet.Tables[0].Rows[0]["HEAR_ABOUT_US_ID"]);
                person.OtherHearAboutUsId = dataSet.Tables[0].Rows[0]["OTHER_HEAR_ABOUT_US_DESC"].ToString();
                person.IsPrimary = Convert.ToInt32(dataSet.Tables[0].Rows[0]["IS_PRIMARY"] == DBNull.Value ? 0 : dataSet.Tables[0].Rows[0]["IS_PRIMARY"]);
                person.IsStaging = Convert.ToInt32(dataSet.Tables[0].Rows[0]["IS_STAGING"] == DBNull.Value ? 0 : dataSet.Tables[0].Rows[0]["IS_STAGING"]);
                person.PrimaryId = Convert.ToInt32(dataSet.Tables[0].Rows[0]["PRIMARY_ID"] == DBNull.Value ? 0 : dataSet.Tables[0].Rows[0]["PRIMARY_ID"]);
                person.AddressNoteId = Convert.ToInt32(dataSet.Tables[0].Rows[0]["ADDRESS_NOTE_ID"] == DBNull.Value ? 0 : dataSet.Tables[0].Rows[0]["ADDRESS_NOTE_ID"]);
                person.AddressNoteDate = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["ADDRESS_NOTE_DT"] == DBNull.Value ? null : dataSet.Tables[0].Rows[0]["ADDRESS_NOTE_DT"]);
            }
            else
                throw new Exception("Retrieve Person Returned 0 Records");
            return person;
        }

        // ' summary
        // ' Return Staged Users waiting to be validated (Paginated)
        // ' /summary
        // ' returnsList of Staged users/returns
        // ' remarksBound to Grid/remarks
        public static List<StageValidationList> ListStageValidationPersons()   //= 50, int startRowIndex = 1)
        {
            List<StageValidationList> stageValidationLists = new List<StageValidationList>();
            OleDbCommand oleDbCommand = new OleDbCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "spListStageValidationRecords"
            };
            DataSet dataSet = DataProcess.SqlConnection.ExecuteSelectParameterizedQuery(oleDbCommand);
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
            if (stageValidationLists.Count != 0)
            {
                _listStageValidationPersonsCount = Convert.ToInt32(stageValidationLists[0].TotalRecords);
            }
            return stageValidationLists.OrderByDescending(x => x.PersonID).ToList();
        }

        public static List<StageValidationList> ListStageValidationPersons(string lastName, string firstName, string phoneNumber)   //= 50, int startRowIndex = 1)
        {
            List<StageValidationList> stageValidationLists = new List<StageValidationList>();
            OleDbCommand oleDbCommand = new OleDbCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "spListStageValidationRecords"
            };
            DataSet dataSet = DataProcess.SqlConnection.ExecuteSelectParameterizedQuery(oleDbCommand);
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
            if (lastName != "")
                stageValidationLists = stageValidationLists.Where(x => x.LastName.ToUpper().Contains(lastName.ToUpper())).ToList();
            if (firstName != "")
                stageValidationLists = stageValidationLists.Where(x => x.FirstName.ToUpper().Contains(firstName.ToUpper())).ToList();
            if (phoneNumber != "")
                stageValidationLists = stageValidationLists.Where(x => x.PrimaryPhoneNumber.Contains(phoneNumber)).ToList();
            if (stageValidationLists.Count != 0)
                _listStageValidationPersonsCount = Convert.ToInt32(stageValidationLists[0].TotalRecords);
            return stageValidationLists.OrderByDescending(x => x.PersonID).ToList();
        }


        private static int _listStageValidationPersonsCount = 0;

        public int ListStageValidationPersonsCount()
        {
            return _listStageValidationPersonsCount;
        }


        // ' summary
        // ' Update Person and Address record from model
        // ' /summary
        // ' param name="editUserID"Editing User ID/param
        // ' param name="person"Person Model/param
        // ' param name="address"Address Model/param
        // ' remarksPrimarly used in CLNR Edit Screen/remarks
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

        // ' summary
        // ' Insert a new Person into database
        // ' /summary
        // ' returnsnew Person PK ID/returns
        private int InsertPerson(Person person, int userId)
        {
            //Define Stored Proc + Paramaters
            OleDbCommand oleDbCommand = new OleDbCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "spInsertPerson"
            };
            oleDbCommand.Parameters.AddWithValue("@p_last_name", person.LastName);
            oleDbCommand.Parameters.AddWithValue("@p_first_name", person.FirstName);
            oleDbCommand.Parameters.AddWithValue("@p_middle_name", CspNothing(person.MiddleInitial));
            oleDbCommand.Parameters.AddWithValue("@p_varstatus", CspNothing(person.VarStatus));
            oleDbCommand.Parameters.AddWithValue("@p_email_address", CspNothing(person.EmailAddress));
            oleDbCommand.Parameters.AddWithValue("@p_varstationed", CspNothing(person.VarStationed));
            oleDbCommand.Parameters.AddWithValue("@p_varworked", CspNothing(person.VarWorked));
            oleDbCommand.Parameters.AddWithValue("@p_varreside", CspNothing(person.VarReside));
            oleDbCommand.Parameters.AddWithValue("@p_varnone", CspNothing(person.VarNone));
            oleDbCommand.Parameters.AddWithValue("@p_suffix_id", CipNothing(person.SuffixId));
            oleDbCommand.Parameters.AddWithValue("@p_primary_phone", person.PrimaryPhone);
            oleDbCommand.Parameters.AddWithValue("@p_alternate_phone", CspNothing(person.AlternatePhone));
            oleDbCommand.Parameters.AddWithValue("@p_comments", "");
            oleDbCommand.Parameters.AddWithValue("@p_hear_about_us_id", CipNothing(person.HearAboutUsId));
            oleDbCommand.Parameters.AddWithValue("@p_other_hear_about_us_desc", CspNothing(person.OtherHearAboutUsId));
            oleDbCommand.Parameters.AddWithValue("@p_is_staging", person.IsStaging == null ? 0 : person.IsStaging);
            oleDbCommand.Parameters.AddWithValue("@p_is_primary", person.IsPrimary == null ? 0 : person.IsPrimary);
            oleDbCommand.Parameters.AddWithValue("@p_primary_id", CipNothing(person.PrimaryId));
            oleDbCommand.Parameters.AddWithValue("@p_edited_by", userId);
            oleDbCommand.Parameters.AddWithValue("@p_reg_type_id", person.RegistrationTypeId);
            DataSet dataSet = DataProcess.SqlConnection.ExecuteSelectParameterizedQuery(oleDbCommand);
            return Convert.ToInt32(dataSet?.Tables[0].Rows[0][0]);
        }


        // ' summary
        // ' Function to check database for Duplicate Person/Address combination during public  facing form collection
        // ' /summary
        // ' param name="person"Person Model/param
        // ' param name="address"Address Model/param
        // ' returnsBoolean Result/returns
        public bool IsDuplicte(Person person, Address address)
        {
            int count = 0;
            OleDbCommand oleDbCommand = new OleDbCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "spIsDuplicate"
            };
            oleDbCommand.Parameters.AddWithValue("@p_last_name", person.LastName);
            oleDbCommand.Parameters.AddWithValue("@p_first_name", person.FirstName);
            oleDbCommand.Parameters.AddWithValue("@p_suffix_id", CipNothing(person.SuffixId));
            oleDbCommand.Parameters.AddWithValue("@p_primary_phone", person.PrimaryPhone);
            oleDbCommand.Parameters.AddWithValue("@p_city", CspNothing(address.City));
            oleDbCommand.Parameters.AddWithValue("@p_zipcode", CspNothing(address.ZipCode));
            oleDbCommand.Parameters.AddWithValue("@p_state_id", CipNothing(address.StateId));
            oleDbCommand.Parameters.AddWithValue("@p_country_id", CipNothing(address.CountryId));
            oleDbCommand.Parameters.AddWithValue("@p_address_1", address.Address1);
            oleDbCommand.Parameters.AddWithValue("@p_address_2", CspNothing(address.Address2));
            DataSet dataSet = DataProcess.SqlConnection.ExecuteSelectParameterizedQuery(oleDbCommand);
            if (dataSet?.Tables[0].Rows.Count == 0)
                return false;
            return Convert.ToInt32(dataSet?.Tables[0].Rows[0][0]) != 0;
        }

        // ' summary
        // ' Insert new Person/Address
        // ' /summary
        // ' param name="address"Address Model/param
        // ' param name="Person"Person Model/param
        // ' param name="userId"UserID to pass for Created/Edited By ID/param
        // ' remarksDesigned at this point for public  collection form/remarks
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

        // ' summary
        // ' Retrieve an Address
        // ' /summary
        // ' param name="personId"Person PK ID/param
        // ' returnsAddress Model/returns
        public Address RetrieveAddress(int personId)
        {
            Address address = new Address
            {
                PersonId = personId
            };
            OleDbCommand oleDbCommand = new OleDbCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "spRetrieveAddress"
            };
            oleDbCommand.Parameters.AddWithValue("@p_person_id", personId);
            DataSet dataSet = DataProcess.SqlConnection.ExecuteSelectParameterizedQuery(oleDbCommand);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                address.AddressId = Convert.ToInt32(dataSet.Tables[0].Rows[0]["ADDRESS_ID"] == DBNull.Value ? 0 : dataSet.Tables[0].Rows[0]["ADDRESS_ID"]);
                address.Address1 = dataSet.Tables[0].Rows[0]["ADDRESS_1"].ToString();
                address.Address2 = dataSet.Tables[0].Rows[0]["ADDRESS_2"].ToString();
                address.City = dataSet.Tables[0].Rows[0]["CITY"].ToString();
                address.StateId = Convert.ToInt32(dataSet.Tables[0].Rows[0]["STATE_ID"] == DBNull.Value ? 0 : dataSet.Tables[0].Rows[0]["STATE_ID"]);
                address.ZipCode = dataSet.Tables[0].Rows[0]["ZIPCODE"].ToString();
                address.CountryId = Convert.ToInt32(dataSet.Tables[0].Rows[0]["COUNTRY_ID"] == DBNull.Value ? 0 : dataSet.Tables[0].Rows[0]["COUNTRY_ID"]);
                address.OtherStateDescription = dataSet.Tables[0].Rows[0]["OTHER_STATE_DESC"].ToString();
            }
            else
            {
                throw new Exception("Retrieve Address Returned 0 Records");
            }
            return address;
        }

        // ' summary
        // ' Retrieve a persons comment and notification count
        // ' /summary
        // ' param name="personId"Person PK ID/param
        // ' returnsNotification and Comment model/returns
        public NotificationCommentCount RetrieveNotificationCommentCount(int personId)
        {
            NotificationCommentCount notificationCommentCount = new NotificationCommentCount();
            OleDbCommand oleDbCommand = new OleDbCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "spRetrieveCommentNotifCount"
            };
            oleDbCommand.Parameters.AddWithValue("@p_person_id", personId);
            DataSet dataSet = DataProcess.SqlConnection.ExecuteSelectParameterizedQuery(oleDbCommand);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                notificationCommentCount.CommentCount = Convert.ToInt32(dataSet.Tables[0].Rows[0]["comment_count"] == DBNull.Value ? 0 : dataSet.Tables[0].Rows[0]["comment_count"]);
                notificationCommentCount.NotificationCount = Convert.ToInt32(dataSet.Tables[0].Rows[0]["notification_count"] == DBNull.Value ? 0 : dataSet.Tables[0].Rows[0]["notification_count"]);
            }
            else
            {
                throw new Exception("Retrieve Comment/Notifications Returned 0 Records");
            }
            return notificationCommentCount;
        }


        // ' summary
        // ' Retrieve list of possible duplicates for person/address information
        // ' /summary
        // ' param name="person"Person Model/param
        // ' param name="address"Address Model/param
        // ' returnsList of Duplicates/returns
        public List<CompletePerson> RetrieveDuplicates(Person person, Address address)
        {
            List<CompletePerson> completePersons = new List<CompletePerson>();
            OleDbCommand oleDbCommand = new OleDbCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "spRetrieveDuplicates"
            };
            oleDbCommand.Parameters.AddWithValue("@p_address_1", address.Address1);
            oleDbCommand.Parameters.AddWithValue("@p_address_2", CspNothing(address.Address2));
            oleDbCommand.Parameters.AddWithValue("@p_city", CspNothing(address.City));
            oleDbCommand.Parameters.AddWithValue("@p_state_id", CipNothing(address.StateId));
            oleDbCommand.Parameters.AddWithValue("@p_zipcode", CspNothing(address.ZipCode));
            oleDbCommand.Parameters.AddWithValue("@p_country_id", CipNothing(address.CountryId));
            oleDbCommand.Parameters.AddWithValue("@p_last_name", person.LastName);
            oleDbCommand.Parameters.AddWithValue("@p_first_name", person.FirstName);
            oleDbCommand.Parameters.AddWithValue("@p_person_id", person.PersonId);
            oleDbCommand.Parameters.AddWithValue("@p_primary_phone", CspNothing(person.PrimaryPhone));
            DataSet dataSet = DataProcess.SqlConnection.ExecuteSelectParameterizedQuery(oleDbCommand);
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
            return completePersons;
        }

        // ' summary
        // ' Insert a Person Comment
        // ' /summary
        // ' param name="userID"User ID/param
        // ' param name="comment"Comment Object/param
        // ' param name="conn"Open Connection/param
        // ' param name="trans"Open Transaction/param
        // ' remarks/remarks
        public void InsertComment(int userId, Comment comment)
        {
            OleDbCommand oleDbCommand = new OleDbCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "spInsertComment"
            };
            oleDbCommand.Parameters.AddWithValue("@p_user_id", userId);
            oleDbCommand.Parameters.AddWithValue("@p_person_id", comment.PersonId);
            oleDbCommand.Parameters.AddWithValue("@p_comment", comment.CommentDesc);
            DataProcess.SqlConnection.ExecuteNonSelectParameterizedQuery(oleDbCommand);
        }
    }
}