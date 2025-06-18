
var $footerHelper = $footerHelper || {};
$footerHelper = function () {

    const create = function (href) {

        const footer = document.createElement('footer');
        footer.classList.add('fixed-bottom', 'p-3', 'text-center');
        footer.style.backgroundColor = '#0f506f';

        const span = document.createElement('span');
        span.classList.add('text-white');

        const div = document.createElement('div');
        div.classList.add('footer');

        const link = document.createElement('a');
        link.classList.add('text-white');
        link.style.textDecoration = 'none';
        link.style.fontWeight = 'bold';

        link.href = `${href}`;
        link.target = '_blank';
        link.setAttribute('aria-label', 'Link to Microsoft Visual Studio home page');

        link.textContent = 'Visit Microsoft Visual Studio home page';

        
        div.appendChild(link);
        span.appendChild(div);
        footer.appendChild(span);

        return footer;
    };

    // Exposed API
    return { create: create };

}();