var r = 150;
var g = 150;
var b = 0;

document.body.style.backgroundColor = 'rgb(' + r + ',' + g + ',' + b + ')';

var sw = 1;

let timerId = setInterval(() => change_background(), 1);

function change_background() 
{
		sw=sw*(-1);
		if(sw==1)
		{
			document.body.style.backgroundColor = 'rgb(' + 250 + ',' + 0 + ',' + 0 + ')';
			document.b.style.color = 'rgb(' + 0 + ',' + 250 + ',' + 0 + ')';
		} 
		else {
			document.body.style.backgroundColor = 'rgb(' + 0 + ',' + 250 + ',' + 0 + ')';
			document.b.style.color = 'rgb(' + 250 + ',' + 0 + ',' + 0 + ')'; 
		}


		r=r+sw;
		g=g+sw*(-1);
		
		if(r > 160)
		{
			sw=-1;
		}
		if(r < 140)
		{
			sw=1;
		}
	//document.body.style.backgroundColor = 'rgb(' + r + ',' + g + ',' + b + ')';
}

function swapStyleSheet(sheet)
{
     document.getElementById('pagestyle').setAttribute('href', sheet);
}

function amogusEnter()
{
	document.getElementById("amogus").width=1000;
}
function amogusLeave()
{
	document.getElementById("amogus").width=200;
}