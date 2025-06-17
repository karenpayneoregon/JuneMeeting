```javascript
const form = document.getElementById('myForm');

form.addEventListener('submit', function (event) {
    if (!form.checkValidity()) {
        event.preventDefault();
        event.stopPropagation();
    }

    form.classList.add('was-validated');
}, false);
```

Form

```html
<form id="myForm" novalidate>
```

- This targets a single form, not a collection.
- Uses `checkValidity()` which is native HTML5 validation.
- Adds Bootstrap's `.was-validated` class so Bootstrap will apply the appropriate validation styles.