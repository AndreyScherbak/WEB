var catsPicture = ["resources/1.jpg", "resources/2.jpg", "resources/3.jpg",
"resources/4.jpg", "resources/5.jpg", "resources/6.jpg", "resources/7.jpg"]; // массив src
var numberOfCats = 7; // количество котов
var currentCat = 0; // текущий кот (центральное изображение)


function right(){ //перелистывание котов вправо
	if(currentCat < numberOfCats - 1) // если текущая позиция меньше максимальной
	{
		currentCat++; // то увеличиваем
	}
	else //иначе переводим вначало
	{
		currentCat = 0;
	}
	var centerPicture = document.getElementById('centercat'); 
	centerPicture.src = catsPicture[currentCat];// установка центрального изображения
}	 

function left(){ //перелистывание котов влево
	if(currentCat > 0) // если больше минимальной позиции
	{
		currentCat--; // уменьшаем 
	}
	else
	{
		currentCat = 6; // иначе устанавливаем в конец
	}
	var centerPicture = document.getElementById('centercat');
	centerPicture.src = catsPicture[currentCat];
}
function loadFunc()
{
	var container = document.getElementById('container');
	container.onclick = function (event)  // делегирование (шаблон делегирования взял в сети)
	{
		if (event.target.tagName.toUpperCase() == 'IMG') // если изображение устанавливаем его src к src центрального изображения
		{
			var centerPicture = document.getElementById('centercat');
			var selectedPicture = document.getElementById(event.target.id); 			
			centerPicture.src = selectedPicture.src;
			currentCat = Number(event.target.id); // установка текущей позиции, чтобы корректно работала прокрутка
		}
	}
}