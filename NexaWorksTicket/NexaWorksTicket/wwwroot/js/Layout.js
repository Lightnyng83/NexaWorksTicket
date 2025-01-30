const ApiService = {
    post: async function (url, data) {
        try {
            const response = await fetch(url, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(data)
            });

            return await response.json();
        } catch (error) {
            console.error("Erreur réseau :", error);
            return { success: false, message: "Une erreur réseau est survenue." };
        }
    }
};

const ToastService = {
    showToast: function (message, type = "info") {
        const toastBody = document.getElementById('toastBody');
        const toastTitle = document.getElementById('toastTitle');

        toastBody.textContent = message;
        toastTitle.textContent = type === "success" ? "Succès" : "Erreur";
        toastTitle.className = `me-auto text-${type}`;

        const toastElement = new bootstrap.Toast(document.getElementById('liveToast'));
        toastElement.show();
    }
};

document.addEventListener('submit', async function (e) {
    const form = e.target;

    if (form.hasAttribute('data-api')) {
        e.preventDefault();

        const url = form.getAttribute('data-api');
        const formData = new FormData(form);

        const data = {};
        formData.forEach((value, key) => {
            data[key] = value;
        });

        const result = await ApiService.post(url, data);

        if (result.success) {
            ToastService.showToast(result.message, "success");
        } else {
            ToastService.showToast(result.message, "danger");
        }
    }
});
