using System;
using System.Diagnostics.Contracts;
using System.Net.Mail;

namespace Alertr.Shared
{
    public struct EmailAddress : IEquatable<EmailAddress>, IComparable<EmailAddress>
    {
        public static class Lengths
        {
            public const int MinLength = 8;
            public const int MaxLength = 64;
        }

        private string value;

        public EmailAddress(string value)
        {
            Contract.Requires(value.IsEmailAddress());

            this.value = value;
        }

        public string LocalPart
        {
            get
            {
                return value.Split('@')[0];
            }
        }

        public string HostName
        {
            get
            {
                return value.Split('@')[1];
            }
        }

        public bool Equals(EmailAddress email)
        {
            return value.Equals(email.value);
        }

        public int CompareTo(EmailAddress email)
        {
            return value.CompareTo(email.value);
        }

        public override string ToString()
        {
            return value;
        }

        public static readonly EmailAddress Empty;

        public static implicit operator EmailAddress(string email)
        {
            return new EmailAddress(email);
        }

        public static implicit operator string(EmailAddress email)
        {
            return email.value;
        }
    }
}
