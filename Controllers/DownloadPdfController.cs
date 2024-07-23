using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using CV_Central.App.Services;
using CV_Central.Models;
using CV_Central.Context;

namespace CV_Central.Controllers
{
    public class DownloadPdfController : Controller
    { 
        private readonly CVCentralContext _context;
        public DownloadPdfController(CVCentralContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<IActionResult> DownloadPdf(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(e => e.Id == id);
            if (user == null) return NotFound();

            var pdf = GenerarPdf(user);
            var pdfStream = new MemoryStream();
            pdf.Save(pdfStream, false);

            pdfStream.Position = 0;
            return File(pdfStream, "application/pdf", "DatosEstudiante.pdf");
        }

        private PdfDocument GenerarPdf(User user)
        {
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Datos del user";

            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Arial", 14);

            gfx.DrawString($"Nombre: {user.Name}", font, XBrushes.Black, new XRect(20, 20, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString($"Edad: {user.Age}", font, XBrushes.Black, new XRect(20, 40, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString($"Correo: {user.Email}", font, XBrushes.Black, new XRect(20, 60, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString($"Celular: {user.Phone}", font, XBrushes.Black, new XRect(20, 80, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString($"Direccion: {user.Address}", font, XBrushes.Black, new XRect(20, 100, page.Width, page.Height), XStringFormats.TopLeft);
            //gfx.DrawString($"Habilidades: {Skills.SkillName}", font, XBrushes.Black, new XRect(20, 100, page.Width, page.Height), XStringFormats.TopLeft);
/*          gfx.DrawString($"Nivel: {user.Skills.ProficiencyLevel}", font, XBrushes.Black, new XRect(0, 40, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString($"Formacion academica: {user.AcademicFormation.Institution}", font, XBrushes.Black, new XRect(0, 40, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString($"Formacion academica: {user.AcademicFormation.Institution}", font, XBrushes.Black, new XRect(0, 40, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString($"Formacion academica: {user.AcademicFormation.Title}", font, XBrushes.Black, new XRect(0, 40, page.Width, page.Height), XStringFormats.TopLeft); */

            return document;
        }

    }
}