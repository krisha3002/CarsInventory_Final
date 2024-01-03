// CarsInventoryMvc/Controllers/CarsController.cs
using CarsInventoryMvc.Models;
using Microsoft.AspNetCore.Mvc;

public class CarsController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CarsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        var cars = _unitOfWork.CarRepository.GetAll();
        return View(cars);
    }

    public IActionResult Details(int id)
    {
        var car = _unitOfWork.CarRepository.GetById(id);
        return View(car);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Car car)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.CarRepository.Add(car);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(car);
    }

    public IActionResult Edit(int id)
    {
        var car = _unitOfWork.CarRepository.GetById(id);
        return View(car);
    }

    [HttpPost]
    public IActionResult Edit(int id, Car car)
    {
        if (ModelState.IsValid)
        {
            var existingCar = _unitOfWork.CarRepository.GetById(id);
            existingCar.Brand = car.Brand;
            existingCar.Model = car.Model;
            existingCar.Year = car.Year;
            existingCar.Price = car.Price;
            existingCar.New = car.New;

            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(car);
    }

    public IActionResult Delete(int id)
    {
        var car = _unitOfWork.CarRepository.GetById(id);
        return View(car);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var car = _unitOfWork.CarRepository.GetById(id);
        _unitOfWork.CarRepository.Remove(car);
        _unitOfWork.SaveChanges();
        return RedirectToAction("Index");
    }
}
