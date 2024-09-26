'use strict';

const form = document.getElementById('regForm');

form.addEventListener('submit', async (e) => {
    e.preventDefault();

    const email = document.getElementById('Email').value;
    const login = document.getElementById('Login').value;
    const password = document.getElementById('Password').value;
    const confirmPassword = document.getElementById('ConfirmPassword').value;

    const response = await fetch('/api/Account/register', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            email,
            login,
            password,
            confirmPassword
        })
    });

    document.querySelectorAll('.tooltip').forEach(tooltip => tooltip.remove());
    if (!response.ok) {
        const {errors} = await response.json();
        Object.keys(errors).forEach(field => {
            const inputField = document.getElementById(field);
            if (inputField) {
                showTooltip(inputField, errors[field].join(', '));
            } else {
                console.warn(`Field with ID "${field}" not found in form`);
            }
        });
    } else {
        alert(`Successful registration! You can now log in with your new account`);
        window.location.href = '../pages/auth.html';
    }
});

function showTooltip(inputField, message) {
    const tooltip = document.createElement('div');
    tooltip.className = 'error-tooltip';
    tooltip.innerText = message;

    inputField.parentNode.appendChild(tooltip);
    inputField.classList.add('input-error');
}
