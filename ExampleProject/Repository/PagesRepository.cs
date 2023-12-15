using ExampleProject.Data;
using ExampleProject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using Rotativa.AspNetCore;

namespace ExampleProject.Repository
{
    public class PagesRepository
    {
        private readonly StoreDbContext _context;

        public PagesRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<CompanyModel>> GetCompanyListAsync()
        {
            var companyModel = new List<CompanyModel>();
            var companyData = await _context.CompanyData.ToListAsync();

            if (companyData != null)
            {
                foreach (var company in companyData)
                {
                    companyModel.Add(new CompanyModel()
                    {
                        CompanyName = company.CompanyName,
                        Email = company.Email,
                        GstNumber = company.GstNumber,
                        Id = company.Id,
                        WesternNumber = company.WesternNumber
                    });
                }
                return companyModel;
            }

            return null;
        }
        public async Task<List<DispatcherModel>> GetDispatcherListAsync()
        {
            var dispatcherModel = new List<DispatcherModel>();
            

            var dispatcherData = await _context.DispatcherData.ToListAsync();

            if (dispatcherData != null)
            {
                foreach (var dispatcher in dispatcherData)
                {
                    dispatcherModel.Add(new DispatcherModel()
                    {
                        Id=dispatcher.Id,
                        Amount=dispatcher.Amount,
                        ItemName=dispatcher.ItemName,
                        PartyName=dispatcher.PartyName,
                        Quantity=dispatcher.Quantity,
                        Rate= dispatcher.Rate,
                        Date = dispatcher.Date
                    });
                }
                return dispatcherModel;
            }
            return null;
        }

        
    }
}
