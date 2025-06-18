To set the **default time to 8:00 AM**, you simply need to check each generated time option and set the `selected` attribute on the one that matches `08:00`.

Here’s the updated script with that logic included:

---

## ✅ Full HTML + JavaScript with AM/PM Format and Default 8:00 AM

```html
<label for="time-select">Choose a time:</label>
<select id="time-select" name="time-select"></select>

<script>
  const timeSelect = document.getElementById("time-select");

  function generateTimeOptions(start = "00:00", end = "23:30", stepMinutes = 30, defaultValue = "08:00") {
    const pad = (num) => String(num).padStart(2, '0');
    const [startHour, startMin] = start.split(":").map(Number);
    const [endHour, endMin] = end.split(":").map(Number);

    let current = new Date();
    current.setHours(startHour, startMin, 0, 0);

    const endTime = new Date();
    endTime.setHours(endHour, endMin, 0, 0);

    while (current <= endTime) {
      let hours24 = current.getHours();
      let minutes = current.getMinutes();
      let hours12 = hours24 % 12 || 12;
      let ampm = hours24 < 12 ? 'AM' : 'PM';

      let value = `${pad(hours24)}:${pad(minutes)}`;
      let label = `${hours12}:${pad(minutes)} ${ampm}`;

      const option = document.createElement("option");
      option.value = value;
      option.textContent = label;

      if (value === defaultValue) {
        option.selected = true;
      }

      timeSelect.appendChild(option);
      current.setMinutes(current.getMinutes() + stepMinutes);
    }
  }

  generateTimeOptions("00:00", "23:30", 30, "08:00");
</script>
```

---

## ✅ Result

* Dropdown includes all 30-minute intervals, displayed as `12:00 AM` to `11:30 PM`.
* `8:00 AM` is **pre-selected by default** when the page loads.
* `option.value` remains in 24-hour format for back-end safety (`08:00`).

---

Let me know if you'd prefer a different default like `09:30 AM` or a limited range (e.g., business hours only).
