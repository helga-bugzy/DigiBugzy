﻿namespace DigiBugzy.ApplicationLayer.Common.xBaseObjects.FilterObjects
{
    public interface IFilterObject
    {
        //Basic Entity Fields
        public int Id { get; set; }

        public int DigiAdminId { get; set; }        

        public bool IsDelete { get; set; }

        public bool IsActive { get; set; }


        //Admin entity fields 
        public string Name { get; set; }

        public string Description { get; set; }


        //Other often occurring relational fields
        public int ParentId { get; set; }

        public List<int> ClassificationId { get; set; }

        public List<int> CategoryIds { get; set; }

        public List<CustomFieldModel> CustomFields { get; set; }




    }
}