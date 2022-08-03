document.getElementById('sent').disabled=true;
function CheckMail(element) 
{
	var mask =/^[a-zA-Z0-9._-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-]+$/;
    var this_mail = document.getElementById('email').value;
    if (mask.test(this_mail))
    {
    	alert("Вы ввели правильную почту");
    }
	else
	{
		if (/^\s*$/.test(this_mail))
    		{
      			alert("Почта не может быть пустой!");
    		}
    		else
    			if (/^@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/.test(this_mail))
    			{
      				alert("Отсутствует имя почтового ящика!");
    			}
    			else 
    				if (/^[a-zA-Z0-9._-]+(?:\.[a-zA-Z0-9-]+)*$/.test(this_mail))
    				{
     				 	alert("Пропущен символ '@'!");
    				}
    				else 
    					if (/^[a-zA-Z0-9._-]+@$/.test(this_mail))
    					{
      						alert("Пропущено доменное имя!")
    					}
    					else 
    						if (/^[a-zA-Z0-9._-]+@[a-zA-Z0-9-]+$/.test(this_mail))
    						{
     							alert("Пропущен символ '.'!");
    						}
    						else
    						{
     				 			alert("Адрес содержит некорректные символы!");
    						}

	}
	Button()						
}

function CheckPhone(element) 
{
    var mask =/^\([0-9]{3}\)[0-9]{3}\-?[0-9]{2}\-?[0-9]{2}$/;
    var this_phone = document.getElementById('phone').value;
    if (mask.test(this_phone))
    {
        alert("Вы ввели валидный номер");
    }
    else
    {
        if (/^\s*$/.test(this_phone))
    {
      alert("Номер не может быть пустым!");
    }
    else if (/^\(?[0-9]{3}\)?[0-9]{3}\-?[0-9]{2}\-?[0-9]{2}$/.test(this_phone))
    {
      alert("Одна или обе скобки отсутствуют!");
    }
    else if (/^\([0-9]{0,3}\)[0-9]{0,3}\-?[0-9]{0,2}\-?[0-9]{0,2}$/.test(this_phone))
    {
      alert("Номер содержит недостаточно цифр!")
    }
    else if (/^\([0-9]{3,}\)[0-9]{3,}\-?[0-9]{2,}\-?[0-9]{2,}$/.test(this_phone))
    {
      alert("Номер содержит слишком много цифр!")
    }
    else if (/^\(?[0-9]*\)?[0-9]*\-?[0-9]*\-?[0-9]*$/.test(this_phone))
    {
      alert("Номер отформатирован неправильно!")
    }
    else
    {
      alert("Номер содержит некорректные символы!")
    }
}
Button()	
} 

function CheckPhoneOnMask()
{
	var mask =/^\([0-9]{3}\)[0-9]{3}\-?[0-9]{2}\-?[0-9]{2}$/;
    var this_phone = document.getElementById('phone').value;
    if (mask.test(this_phone))
    {
        return true;
    }
    else
    {
        return false;
    }
}
function CheckMailOnMask()
{
	var mask =/^[a-zA-Z0-9._-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-]+$/;
    var this_mail = document.getElementById('email').value;
    if (mask.test(this_mail))
    {
        return true;
    }
    else
    {
        return false;
    }
}
 function Button()
 {
 	if(CheckPhoneOnMask()&&CheckMailOnMask())
 	{
 		document.getElementById('sent').disabled=false;
 	}
 	else
 	{
 		document.getElementById('sent').disabled=true;
 	}
 }