using CV_Central.Context;
using CV_Central.Models;
using Microsoft.EntityFrameworkCore;
using CV_Central.DTOs;

namespace CV_Central.App.Services{
    public class AcademicFormationRepository{
        private readonly CVCentralContext _context;
        public AcademicFormationRepository(CVCentralContext context){
            _context = context;
        }

        // Encontrar la formaciòn academica del ususario
        public async Task<AcademicFormation> GetAcademicFormation(int userId){
            return await _context.AcademicFormation.FirstOrDefaultAsync(af => af.UserId == userId);
        }
    }
}