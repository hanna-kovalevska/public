function showHide(element_id) {
    if (document.getElementById(element_id)) //находим нужный заголовок с данным id
    { 
        var this_object = document.getElementById(element_id); 
        if (this_object.style.display != "block") 
        { 
            this_object.style.display = "block"; //если скрыто, то открываем
        }
            else this_object.style.display = "none"; //прячем
        }
    }   