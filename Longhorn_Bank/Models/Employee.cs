using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System;

namespace Longhorn_Bank.Models
{ 
    public enum EmpType { Employee, Manager }
    public class Employee : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public StateAbrv State { get; set; }
        public string ZipCode { get; set; }
        public DateTime DOB { get; set; }
        public string MiddleInitial { get; set; }
        
        public string SSN { get; set; }
        public EmpType EmpType { get; set; }
    }
}