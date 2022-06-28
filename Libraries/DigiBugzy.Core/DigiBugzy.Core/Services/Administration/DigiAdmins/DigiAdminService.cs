

namespace DigiBugzy.ApplicationLayer.Services.Administration.DigiAdmins
{
    public partial class DigiAdminService
    {
        private readonly string _connectionString;
        private readonly IMapper _mapper;

        private Domain.DatabaseContext _context { get; set; }

        public DigiAdminService(string connectionString)
        {
            _connectionString = connectionString;
            _context = new Domain.DatabaseContext(_connectionString);
        }


        public Task DeleteItem<IResponseObject, IRequestObject>(DeleteDigiAdminRequest request, bool hardDelete = false)
        {
            
            var entities = _context.DigiAdmins
                .Where(x => request.Models.Any(model => model.Id == x.Id)).ToList();
            _context.DigiAdmins.RemoveRange(entities);
            _context.SaveChanges();

            return Task.CompletedTask;
        }

        

        public Task<IEnumerable<DigiAdmin>> Get<CreateDigiAdminResponse>(StandardFilter filter)
        {
            List<DigiAdmin> results = _context.DigiAdmins.ToList();

            if (filter.Id > 0)
            {
                results = (from x in results where x.Id == filter.Id select x).ToList();
                return (Task<IEnumerable<DigiAdmin>>)(results as IEnumerable<DigiAdmin>);
            }

            if (!filter.IncludeDeleted) results = (from x in results 
                                                   where x.IsDeleted == false 
                                                   select x).ToList();

            if (!filter.IncludeInActive) results = (from x in results 
                                                    where x.IsActive == true 
                                                    select x).ToList();

            if (!string.IsNullOrEmpty(filter.Name)) results = (
                    from x in results 
                    where x.Name.Contains(filter.Name) 
                    select x).ToList();

            if (!string.IsNullOrEmpty(filter.Description)) results = (
                    from x in results 
                    where x.Name.Contains(filter.Description) 
                    select x).ToList();

            return (Task<IEnumerable<DigiAdmin>>)(results as IEnumerable<DigiAdmin>);
        }
    }

}
