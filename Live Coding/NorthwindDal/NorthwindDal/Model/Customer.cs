using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace NorthwindDal.Model;

public partial class Customer : IDataErrorInfo
{
    #region IDataErroInfo
    public string this[string columnName]
    {
        get
        {
            string error = null;

            if (columnName == "CustomerId")
            {
                if (string.IsNullOrWhiteSpace(this.CustomerId))
                {
                    error = "CustomerId darf nicht leer blieben";
                }
                else if (this.CustomerId.Length!=5)
                {
                    error = "CustomerId muss 5 Zeichen lang sein.";
                }
            }

            if (columnName=="CompanyName")
            {
                // Checks für die CompanyName-Property hier
            }

            return error;
        }
    }

    public string Error
    {
        get
        {
            return null;
        }
    }

    #endregion

    public string CustomerId { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string? ContactName { get; set; }

    public string? ContactTitle { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Region { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public byte[]? Timestamp { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

}
