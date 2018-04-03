using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Part_4
{
    public class Component
    {
        private string myUrl;
        private string myName;
        private string myDescription;
        private string myPrice;
        private string myType;

        public Component(string url, string name, string description, string price, string type)
        {
            myUrl = url;
            myName = name;
            myDescription = description;
            myPrice = price;
            myType = type;
        }

        public string Url
        {
            get => myUrl;
            set => myUrl = value;
        }

        public string Name
        {
            get => myName;
            set => myName = value;
        }

        public string Description
        {
            get => myDescription;
            set => myDescription = value;
        }

        public string Price
        {
            get => myPrice;
            set => myPrice = value;
        }

        public string Type
        {
            get => myType;
            set => myType = value;
        }
    }
}