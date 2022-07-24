namespace DigiBugzy.Data.Common.xBaseObjects.FilterObjects
{
    public interface IFilterObject
    {
        //Basic Entity Fields
        public int? Id { get; set; }

        public int? DigiAdminId { get; set; }        

        public bool IncludeDeleted { get; set; }

        public bool IncludeInActive { get; set; }


        //Admin entity fields 
        public string Name { get; set; }

        public string Description { get; set; }


        //Other often occurring relational fields
        public int? ParentId { get; set; }

        public int? ClassificationId { get; set; }

        public int? CategoryId { get; set; }

        public List<CustomFieldListOption> CustomFields { get; set; }

        //General
        public bool LikeSearch { get; set; }




    }
}
