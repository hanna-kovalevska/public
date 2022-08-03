var flag =false

document.onkeydown= function hotkey(event) 
{
    var shift = 16;
    var enter = 13;
    if (event.code == 'ShiftLeft') 
    {
        flag=true
    }
    if (event.code == "Digit1" &&flag)
    {
        flag =false
        location.hash='';
        location.hash="p1";
    }
    if (event.code == "Digit2" &&flag)
    {
        flag =false
        location.hash='';
        location.hash="p2";
    }
    if (event.code == "Digit3" &&flag)
    {
        flag =false
        location.hash='';
        location.hash="p3";
    }
    if (event.code == "Digit4" &&flag)
    {
        flag =false
        location.hash='';
        location.hash="p4";
    }
    if (event.code == "Digit5" &&flag)
    {
        flag =false
        location.hash='';
        location.hash="p5";
    }
    if (event.code == 'Enter') 
    {
        location.hash='';
        location.hash="go";
    }
}
