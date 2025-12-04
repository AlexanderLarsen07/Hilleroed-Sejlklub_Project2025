using Hillerød_Sejlklub_Library.Models.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Hillerød_Sejlklub_Library.Models
{
    public class Blog
    {
        private DateTime _startDate;
        private DateTime _lastUpdateDate;

        public DateTime Date
        {
            get; set; //full eller auto?
        }
        public string Headline
        {
            get; private set;
        }

        public List<Comment> CommentsOnBlog
        {
            get; set; //full? auto?
        }
        public Member Member
        {
            get; private set;
        }
        public string TheText
        {
            get; private set;
        }
        public string Description
        {
            get; private set;
        }
        public Blog(string headline, Member member, string theText, string description)
        {
            Headline = headline;
            Member = member;
            TheText = theText;
            Description = description;
        }
        public override string ToString()
        {
            return $"Member: {Member}   Headline: {Headline}    the Text: {TheText}    Description: {Description}   Date: {Date}";
        }
    }
}