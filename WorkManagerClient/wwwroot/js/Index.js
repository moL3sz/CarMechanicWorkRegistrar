namespace WorkManagerClient.wwwroot.js
{
    public class Index
    {
    const severityInput = document.getElementById('severity');
    const severityValue = document.getElementById('severity-value');

        // Az eseményfigyelő figyeli a "input" eseményt az input mezőn, majd megjeleníti a számértéket a "severity-value" elemen.
        severityInput.addEventListener('input', function() {
        severityValue.innerText = severityInput.value;

        // A számértéket százalékosan kiszámoljuk és megfelelően alkalmazzuk a "background-image" CSS tulajdonságra, hogy megjelenítsük a halvány számot a skála fölött.
        const percentage = (severityInput.value - severityInput.min) / (severityInput.max - severityInput.min) * 100;
        severityInput.style.backgroundImage = `linear-gradient(to right, #28a745 0%, #28a745 ${percentage}%, #f5f5f5 ${percentage}%, #f5f5f5 100%)`;
        });
    }
}
