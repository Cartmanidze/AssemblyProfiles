using AssemblyProfiles.Core.Services.HtmlParseService;
using AssemblyProfiles.Core.Storage;
using HtmlAgilityPack;
using System;
using AssemblyProfiles.Core.Helpers.InnerText;
using System.Collections.Generic;
using AssemblyProfiles.Data;

namespace AssemblyProfile.SocialNetworks.LinkedIn
{
    internal class LinkedInHtmlParseService : IHtmlParseService
    {
        private  HtmlDocument _htmlDocument;

        private const string _xPathContacts = "//div[@class='pv-profile-section__section-info section-info']";

        private const string _xPathProfileName = "//li[@class='inline t-24 t-black t-normal break-words']";

        private const string _xPathWorkingExpereince = "//a[@data-control-name='background_details_company']";

        private const string _xPathEducation = "//a[@data-control-name='background_details_school']";

        private const string _xPathLicense = "//div[@class='pv-certifications__summary-info pv-entity__summary-info pv-entity__summary-info--background-section ']";

        private const string _xPathArchivments = "//div[@class='pv-accomplishments-block__content break-words']";

        IProfile IHtmlParseService.GetProfileFromHtml(object html)
        {
            if (html is KeyValuePair<string, string> sources)
            {
                _htmlDocument = new HtmlDocument();
                var contacts = GetContactInformation(sources.Value);
                _htmlDocument.LoadHtml(sources.Key);
                var name = GetProfileName();
                var experiences = GetWorkingExpereinces();
                var education = GetEducation();
                return new LinkedInProfile()
                {
                    Name = name,
                    Contacts = contacts,
                    Experience = experiences,
                    Education = education
                };
            }
            throw new ArgumentException();
        }

        private string GetProfileName()
        {
            return GetNodeValue(_xPathProfileName);
        }

        private string GetContactInformation(string source)
        {
            _htmlDocument.LoadHtml(source);
            return GetNodeValue(_xPathContacts);
        }

        private List<string> GetWorkingExpereinces()
        {
            return GetNodeValuesList(_xPathWorkingExpereince);
        }

        private List<string> GetEducation()
        {
            List<string> education = new List<string>();
            HtmlNodeCollection nodes = _htmlDocument.DocumentNode
                .SelectNodes(_xPathEducation);
            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    var innerText = node.InnerText;
                    if (!string.IsNullOrEmpty(innerText) || !string.IsNullOrWhiteSpace(innerText))
                    {
                        education.Add(innerText.RemovePadding().RemoveExtraSpaces());
                    }
                }
            }
            return education;
        }

        private List<string> GetLicenses()
        {
            List<string> licenses = new List<string>();
            HtmlNodeCollection nodes = _htmlDocument.DocumentNode
                .SelectNodes(_xPathLicense);
            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    var innerText = node.InnerText;
                    if (!string.IsNullOrEmpty(innerText) || !string.IsNullOrWhiteSpace(innerText))
                    {
                        licenses.Add(innerText.RemovePadding().RemoveExtraSpaces());
                    }
                }
            }
            return licenses;
        }

        private List<string> GetAchievements()
        {
            List<string> achievements = new List<string>();
            HtmlNodeCollection nodes = _htmlDocument.DocumentNode
                .SelectNodes(_xPathArchivments);
            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    var innerText = node.InnerText;
                    if (!string.IsNullOrEmpty(innerText) || !string.IsNullOrWhiteSpace(innerText))
                    {
                        achievements.Add(innerText.RemovePadding().RemoveExtraSpaces());
                    }
                }
            }
            return achievements;
        }

        private List<string> GetNodeValuesList(string xPath)
        {
            List<string> nodeValues = new List<string>();
            HtmlNodeCollection nodes = _htmlDocument.DocumentNode.SelectNodes(xPath);
            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    var innerText = node.InnerText;
                    if (!string.IsNullOrEmpty(innerText) || !string.IsNullOrWhiteSpace(innerText))
                    {
                        nodeValues.Add(innerText.RemovePadding().RemoveExtraSpaces());
                    }
                }
            }
            return nodeValues;
        }

        private string GetNodeValue(string xPath)
        {
            HtmlNode node = _htmlDocument.DocumentNode.SelectSingleNode(xPath);
            if (node == null) throw new Exception();
            var innerText = node.InnerText;
            if (!string.IsNullOrEmpty(innerText) || !string.IsNullOrWhiteSpace(innerText))
            {
                return innerText.RemovePadding().RemoveExtraSpaces();
            }
            return string.Empty;
        }

    }
}
