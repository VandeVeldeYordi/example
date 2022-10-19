let app = new Vue({
    el: '#app',
    data: {
        pageTitle: 'Please Log in',
        error: false,
        success: false,
        userMessage: '',
        loading: false,
        apiUrl: 'https://localhost:44318/api/Accounts/Login',
        loginModel: {
            username: '',
            password: '',
        },
    },
    methods: {
        logIn: async function () {
            this.loading = true;
            this.error = false;
            this.success = false;
            let token = '';
            let errorMessage = '';
            let response = await axios.post(this.apiUrl, this.loginModel)
                .then(response => response.data)
                .catch(error => { this.error = true; errorMessage = error })
                .finally(() => { this.loading = false })
            if (this.error === true) {
                if (errorMessage.response.data !== '') {
                    this.userMessage = errorMessage.response.data
                }
                else {
                    this.userMessage = errorMessage;
                }
            }
            else {
                this.success = true;
                this.userMessage = 'Logged in!';
                token = response.token;
                localStorage.setItem('token', `Bearer ${token}`);
            }
        }
    }
});