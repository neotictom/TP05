using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP05.Models;

namespace TP05.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Tutorial(){
        return View();
    }
    public IActionResult Comenzar(){
        int Estado;
        Estado = Escape.GetEstadoJuego();
        if(Estado != 5)
        {
        return View("Habitacion" + Estado.ToString());    
        }
        else
        {
            return View("Victoria");
        }
    }
    public IActionResult Habitacion(int sala, string clave){
        bool v;
        int salaActual;
        v = Escape.ResolverSala(sala,clave);
        if(v){
            salaActual = Escape.GetEstadoJuego();
            if(salaActual != 5){
            return View("Habitacion" + salaActual.ToString());
            }
            else{
                return View("Victoria");
            }
        }
        else{
            salaActual = Escape.GetEstadoJuego();
            return View("Habitacion" + salaActual.ToString());
            ViewBag.Error = "La respuesta es incorrecta";
        }
        
    }
    public IActionResult Creditos()
    {
        return View("Creditos");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
