using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;
using System.Diagnostics;

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
        public string Title { get => title; set => title = value; }
        public string Company { get => company; set => company = value; }
        public string Description { get => description; set => description = value; }
        public string Authors { get => authors; set => authors = value; }
        public Version Version
        {
            get
            {
                var assembly = Assembly.GetExecutingAssembly();
                var assemblyVerzio = assembly.GetName().Version;
                return assemblyVerzio;
            }
        }

      
        

        public ProgramInfo()
        {

            Assembly assembly = Assembly.GetExecutingAssembly();


            foreach (Attribute attr in Attribute.GetCustomAttributes(assembly))
            {
                GetGithubCollaboratorsName();


                if (attr.GetType() == typeof(AssemblyTitleAttribute))
                    Title = ((AssemblyTitleAttribute)attr).Title;
                else if (attr.GetType() == typeof(AssemblyDescriptionAttribute))
                    Description = ((AssemblyDescriptionAttribute)attr).Description;
                else if (attr.GetType() == typeof(AssemblyCompanyAttribute))
                    Company = ((AssemblyCompanyAttribute)attr).Company;

            }

        }
        private async void GetGithubCollaboratorsName()
        {
            string reponame = "borocz-evelin-tilda";
            int repoId = 431761373;
            var client = new GitHubClient(new ProductHeaderValue(reponame));

            // fejlesztők meghatározása
            try
            {
                var collaborators = await client.Repository.GetAllContributors(repoId);
                string collaboratorsName = string.Empty;
                foreach (var collaborator in collaborators)
                {
                    string collaboratorLoginName = collaborator.Login;
                    var user = await client.User.Get(collaboratorLoginName);
                    collaboratorsName += user.Name + " (" + user.Login + ") ";
                }
                authors = collaboratorsName;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

    }
}
