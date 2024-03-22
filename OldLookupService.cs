using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using clwater_new.DataProcess;
using clwater_new.Models;

namespace clwater_new.Services
{
    public class LookupService : ServiceBase
    {
        /// <summary>
        /// Return a list of Suffixes
        /// </summary>
        /// <returns>List of Suffixes</returns>
        public List<Suffix> ListSuffix(bool addSelectEntry = true)
        {
            OleDbCommand oleDbCommand = new OleDbCommand { CommandText = "spGetLKSuffx" };
            DataSet dataSet = SqlConnection.ExecuteSelectParameterizedQuery(oleDbCommand);
            List<Suffix> suffixes = dataSet.Tables[0].AsEnumerable().Select(r => new Suffix
            {
                Id = r.Field<int>("SUFFIX_ID"),
                Description = r.Field<string>("SUFFIX_DESC")
            }).ToList();
            if (!addSelectEntry)
                return suffixes;
            Suffix suffix = new Suffix { Id = 0, Description = "Select Suffix" };
            suffixes.Insert(0, suffix);
            return (suffixes);
        }

        /// <summary>
        /// Return list of States
        /// </summary>
        /// <returns>List of states</returns>
        public List<State> ListStates(bool addSelectEntry = true)
        {
            OleDbCommand oleDbCommand = new OleDbCommand { CommandText = "spGetLKState" };
            DataSet dataSet = SqlConnection.ExecuteSelectParameterizedQuery(oleDbCommand);
            List<State> states = dataSet.Tables[0].AsEnumerable().Select(r => new State
            {
                Id = r.Field<int>("STATE_ID"),
                Description = r.Field<string>("STATE_DESC")
            }).ToList();
            if (!addSelectEntry)
                return states;
            State state = new State { Id = 0, Description = "Select State" };
            states.Insert(0, state);
            return states;
        }

        /// <summary>
        /// List of Countries
        /// </summary>
        /// <returns>List of Countries</returns>
        public List<Country> ListCountries(bool addSelectEntry = true)
        {
            OleDbCommand oleDbCommand = new OleDbCommand { CommandText = "spGetLKCountry" };
            DataSet dataSet = SqlConnection.ExecuteSelectParameterizedQuery(oleDbCommand);
            List<Country> countries = dataSet.Tables[0].AsEnumerable().Select(r => new Country
            {
                Id = r.Field<int>("COUNTRY_ID"),
                Description = r.Field<string>("COUNTRY_DESC")
            }).ToList();
            if (!addSelectEntry)
                return countries;
            Country selectCountry = new Country { Id = 0, Description = "Select Country" };
            countries.Insert(0, selectCountry);
            Country country = countries.FirstOrDefault(x => x.Description == "United States");
            countries.Remove(country);
            countries.Insert(1, country);
            return countries;
        }

        /// <summary>
        /// List Hear About Us entries
        /// </summary>
        /// <returns>List of Hear About Us entries</returns>
        public static List<HearAboutUs> GetHearAboutUsesHearAboutUs(bool addSelectEntry = true)
        {
            OleDbCommand oleDbCommand = new OleDbCommand { CommandText = "spGetLKHearAboutUs" };
            DataSet dataSet = SqlConnection.ExecuteSelectParameterizedQuery(oleDbCommand);
            List<HearAboutUs> hearAboutUses = dataSet.Tables[0].AsEnumerable().Select(r => new HearAboutUs
            {
                Id = r.Field<int>("hear_about_us_id"),
                Description = r.Field<string>("hear_about_us_desc")
            }).ToList();
            if (!addSelectEntry)
                return hearAboutUses;
            HearAboutUs hearAboutUs = new HearAboutUs { Id = 0, Description = "Select" };
            hearAboutUses.Insert(0, hearAboutUs);
            return hearAboutUses;
        }

        /// <summary>
        /// List Address Notes
        /// </summary>
        /// <returns>List of Address Notes</returns>
        /// <remarks>Default N/A</remarks>
        public static List<AddressNote> GetAddressNotes(bool addSelectEntry = true)
        {
            OleDbCommand oleDbCommand = new OleDbCommand { CommandText = "spGetLKAddressNotes" };
            DataSet dataSet = SqlConnection.ExecuteSelectParameterizedQuery(oleDbCommand);
            List<AddressNote> addressNotes = dataSet.Tables[0].AsEnumerable().Select(r => new AddressNote
            {
                Id = r.Field<int>("address_notes_id"),
                Description = r.Field<string>("notes_desc")
            }).ToList();
            if (!addSelectEntry)
                return addressNotes;
            AddressNote addressNote = new AddressNote { Id = 0, Description = "Select" };
            addressNotes.Insert(0, addressNote);
            return addressNotes;
        }

        /// <summary>
        /// List of Registration Types
        /// </summary>
        /// <returns>List of Registration Type Models</returns>
        public static List<RegistrationType> GetRegistrationTypes(bool addSelectEntry = true)
        {
            OleDbCommand oleDbCommand = new OleDbCommand { CommandText = "SELECT *  FROM LK_registration_type " };
            DataSet dataSet = SqlConnection.ExecuteSelectParameterizedQuery(oleDbCommand);
            List<RegistrationType> registrationTypes = dataSet.Tables[0].AsEnumerable().Select(r => new RegistrationType()
            {
                Id = r.Field<int>("REGISTRATION_TYPE_ID"),
                Description = r.Field<string>("REGISTRATION_TYPE_DESC")
            }).ToList();
            if (!addSelectEntry)
                return registrationTypes;
            RegistrationType registrationType = new RegistrationType { Id = 0, Description = "Select" };
            registrationTypes.Insert(0, registrationType);
            return registrationTypes;
        }

        /// <summary>
        /// List of Notification Types
        /// </summary>
        /// <returns>List of Notifiation Type Models</returns>
        public static List<NotificationType> GetNotificationTypes(bool addSelectEntry = true)
        {
            OleDbCommand oleDbCommand = new OleDbCommand { CommandText = "SELECT *  FROM LK_notification_type " };
            DataSet dataSet = SqlConnection.ExecuteSelectParameterizedQuery(oleDbCommand);
            List<NotificationType> notificationTypes = dataSet.Tables[0].AsEnumerable().Select(r => new NotificationType()
            {
                Id = r.Field<int>("NOTIFICATION_TYPE_ID"),
                Description = r.Field<string>("NOTIFICATION_TYPE_DESC")
            }).ToList();
            if (!addSelectEntry)
                return notificationTypes;
            NotificationType notificationType = new NotificationType { Id = 0, Description = "Select" };
            notificationTypes.Insert(0, notificationType);
            return notificationTypes;
        }


        /// <summary>
        /// For Var* Drop Downs that are Yes/No
        /// </summary>
        /// <returns>List of VarGeneric Bindable Results</returns>
        /// <remarks>Yes or No, not in DB so this is best effort to isolate without db scripts</remarks>
        public List<VarGeneric> ListVarYesNo()
        {
            List<VarGeneric> varGenerics = new List<VarGeneric>();
            varGenerics.Add(new VarGeneric("", "Select"));
            varGenerics.Add(new VarGeneric("Yes", "Yes"));
            varGenerics.Add(new VarGeneric("No", "No"));
            return varGenerics;
        }

        /// <summary>
        /// For VarStatus Drop Downs
        /// </summary>
        /// <returns>List of Var Status Bindable Results</returns>
        /// <remarks>Status is not in db so this is a best effort to isolate without db scripts</remarks>
        public List<VarGeneric> ListVarStatus()
        {
            List<VarGeneric> varGenerics = new List<VarGeneric>();
            varGenerics.Add(new VarGeneric("", "Select"));
            varGenerics.Add(new VarGeneric("Not Applicable", "Not Applicable"));
            varGenerics.Add(new VarGeneric("Civilian", "Civilian"));
            varGenerics.Add(new VarGeneric("Contractor", "Contractor"));
            varGenerics.Add(new VarGeneric("Military", "Military"));
            varGenerics.Add(new VarGeneric("Spouse/Dependent", "Spouse/Dependent"));
            varGenerics.Add(new VarGeneric("Other", "Other"));
            return (varGenerics);
        }

        /// <summary>
        /// Retrieve a Hear About Us ID/Description
        /// </summary>
        /// <param name="hearId">Hear About Us ID</param>
        /// <returns>Hear About Us Model</returns>
        /// <remarks>Used when HearAboutUsID is used, then marked as disabled (which would cause binding error)</remarks>
        public HearAboutUs RetrieveHearAboutUs(int? hearId)
        {
            HearAboutUs hearAboutUs = new HearAboutUs
            {
                Id = 0,
                Description = "Select"
            };
            if (hearId == null || hearId == 0)
            {
                hearAboutUs.Id = 0;
                hearAboutUs.Description = "Select";
            }
            else
            {
                OleDbCommand oleDbCommand = new OleDbCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "spRetrieveHearAboutUs"
                };
                oleDbCommand.Parameters.Add(new OleDbParameter("@p_hear_id", hearId));
                DataSet dataSet = DataProcess.SqlConnection.ExecuteSelectParameterizedQuery(oleDbCommand);
                foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                {
                    hearAboutUs.Id = Convert.ToInt32(dataRow["HEAR_ABOUT_US_ID"] == DBNull.Value ? 0 : dataRow["HEAR_ABOUT_US_ID"]);
                    hearAboutUs.Description = Convert.ToString(dataRow["HEAR_ABOUT_US_DESC"]);
                }
            }
            return hearAboutUs;
        }
    }
}