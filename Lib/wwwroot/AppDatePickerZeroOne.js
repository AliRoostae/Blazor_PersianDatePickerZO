const _dpRegistry = new Map();
let _listenerAttached = false;

function _handleDocumentClick(event) {
    for (const [elementId, dotNetHelper] of _dpRegistry) {
        const element = document.getElementById(elementId);
        if (element && !element.contains(event.target)) {
            dotNetHelper.invokeMethodAsync('OnOutsideClick');
        }
    }
}

export function outsideClickHandler(dotNetHelper, elementId) {
    _dpRegistry.set(elementId, dotNetHelper);
    if (!_listenerAttached) {
        document.addEventListener('click', _handleDocumentClick);
        _listenerAttached = true;
    }
}

export function removeOutsideClickHandler(elementId) {
    _dpRegistry.delete(elementId);
    if (_dpRegistry.size === 0 && _listenerAttached) {
        document.removeEventListener('click', _handleDocumentClick);
        _listenerAttached = false;
    }
}