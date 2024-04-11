using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace clwater_new.Models.Grids
{
    public class StageValidationList
    {
        private string _personID;

        public string PersonID
        {
            get { return _personID; }
            set { _personID = value; }
        }

        private string _registrationType;

        public string RegistrationType
        {
            get { return _registrationType; }
            set { _registrationType = value; }
        }
        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        private string _middleInitial;

        public string MiddleInitial
        {
            get { return _middleInitial; }
            set { _middleInitial = value; }
        }
        private string _suffix;

        public string Suffix
        {
            get { return _suffix; }
            set { _suffix = value; }
        }
        private string _primaryPhoneNumber;

        public string PrimaryPhoneNumber
        {
            get { return _primaryPhoneNumber; }
            set { _primaryPhoneNumber = value; }
        }
        private string _city;

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        private string _state;

        public string State
        {
            get { return _state; }
            set { _state = value; }
        }
        private string _zipCode;

        public string ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value; }
        }
        private string _totalRecords;

        public string TotalRecords
        {
            get { return _totalRecords; }
            set { _totalRecords = value; }
        }
    }
}