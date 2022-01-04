using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace Vizsgaremek.Models
{
    public class ProgramInfo
    {
        private Version version;
        private string authors;
        private string title;
        private string description;
        private string company;


        public Version Version
        {
            get
            {
                var assembly = Assembly.GetExecutingAssembly();
                var assemblyVerzio = assembly.GetName().Version;
                return assemblyVerzio;
            }
        }

        public string Authors
        {
            get
            {
                return "";
            }
        }

       
     

        
        public string Title
        {
            get
            {
                var assembly1 = Assembly.GetExecutingAssembly();
                var assemblyTitleAttribute = assembly1.GetType().ToString();
                return assemblyTitleAttribute;
            }
        }
        public string Description
        {
            get
            {
                var assembly2 = Assembly.GetExecutingAssembly();
                var assemblyDescriptionAttribute = assembly2.GetType().ToString();
                return assemblyDescriptionAttribute;
            }
        }
        public string Company
        {
            get
            {
                var assembly3 = Assembly.GetExecutingAssembly();
                var assemblyCompanyAttribute = assembly3.GetType().ToString();
                return assemblyCompanyAttribute;
            }
        }

        public ProgramInfo()
        {

            Assembly assembly = Assembly.GetExecutingAssembly();


            foreach (Attribute attr in Attribute.GetCustomAttributes(assembly))
            {
                if (attr.GetType() == typeof(AssemblyTitleAttribute))
                    Title = ((AssemblyTitleAttribute)attr).Title;
                else if (attr.GetType() == typeof(AssemblyDescriptionAttribute))
                    Description = ((AssemblyDescriptionAttribute)attr).Description;
                else if (attr.GetType() == typeof(AssemblyCompanyAttribute))
                    Company = ((AssemblyCompanyAttribute)attr).Company;

            }




        }
    }
