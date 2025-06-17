(() => {

    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    const forms = document.querySelectorAll('.needs-validation');

    // Loop over them and prevent submission
    Array.from(forms).forEach(form => {
        form.addEventListener('submit', event => {
            if (!form.checkValidity()) {
                event.preventDefault();
                event.stopPropagation();
                console.log('stop');
            } else {
                // form valid, we can continue
                event.preventDefault();
                event.stopPropagation();
                window.location.href = "confirmation.html";
            }

            form.classList.add('was-validated');
        }, false);

    });
})();