window.outsideClickHandler = (dotNetHelper, elementId) => {
    document.addEventListener('click', function (event) {
        const element = document.getElementById(elementId);
        if (element && !element.contains(event.target)) {
          
            dotNetHelper.invokeMethodAsync('OnOutsideClick');
        }
    });
};
