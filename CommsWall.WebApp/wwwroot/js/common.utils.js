window.getElement = (id) => document.getElementById(id);

window.scrollToBottom = (id) => {
    const el = window.getElement(id);
    el.scrollTop = el.scrollHeight;
}