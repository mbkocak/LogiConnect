document.addEventListener('DOMContentLoaded', () => {
    const sidebar = document.querySelector('.sidebar');
    const toggleBtn = document.querySelector('.toggle-btn');
    const container = document.querySelector('.content');

    toggleBtn.addEventListener('click', () => {
        sidebar.classList.toggle('active');
        container.classList.toggle('shifted');

    });
    
});

