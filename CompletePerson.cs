using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace clwater_new.Models.Grids
{
    public class CompletePerson
    {
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
        private string _primaryPhone;
        public string PrimaryPhone
        {
            get { return _primaryPhone; }
            set { _primaryPhone = value; }
        }
        private string _alternatePhone;
        public string AlternatePhone
        {
            get { return _alternatePhone; }
            set { _alternatePhone = value; }
        }
        private int _personID;
        public int PersonID
        {
            get { return _personID; }
            set { _personID = value; }
        }
        private string _city;
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        private string _zipCode;
        public string ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value; }
        }
        private string _address1;
        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }
        private string _address2;
        public string Address2
        {
            get { return _address2; }
            set { _address2 = value; }
        }
        private string _state;
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }
        private string _country;
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        private string _otherStateDesc;
        public string OtherStateDescription
        {
            get { return _otherStateDesc; }
            set { _otherStateDesc = value; }
        }
        private string _addressNoteDesc;
        public string AddressNoteDesc
        {
            get { return _addressNoteDesc; }
            set { _addressNoteDesc = value; }
        }
        private string _addressNoteDate;
        public string AddressNoteDate
        {
            get { return _addressNoteDate; }
            set { _addressNoteDate = value; }
        }
        private string _registrationType;
        public string RegistrationType
        {
            get { return _registrationType; }
            set { _registrationType = value; }
        }
    }
}

