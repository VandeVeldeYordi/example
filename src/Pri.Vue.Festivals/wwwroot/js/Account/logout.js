let app = new Vue({
    el: '#app',
    data: {
        pageTitle: 'log out',
        error: false,
        success: false,
        userMessage: '',
        loading: false,
        apiUrl: 'https://localhost:44318/api/Accounts/Login',    
        token: '' 
    },
    created: async function() {
         this.token = localStorage.getItem('token');
    },
    methods: {
        logout: async function () {
         
            if (this.token === null) {
                window.location.href = '/account';
            }
            this.token = null;
            localStorage.clear();
        }
    }
});