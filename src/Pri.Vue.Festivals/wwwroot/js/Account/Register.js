let app = new Vue({
    el: '#app',
    data: {
        pageTitle: 'Register',
        error: false,
        success: false,
        userMessage: '',
        loading: false,
        apiUrl: 'https://localhost:44318/api/Accounts/Register',
        registerModel: {
            username: '',
            password: '',
            repeatPassword: '',
            firstName: '',
            lastName: '',
            city: '',
            addressLine: '',
            postalCode: '',
            dateOfBirth: '',
        },
    },
    methods: {
        register: async function () {
            this.loading = true;
            this.error = false;
            this.success = false;
            let errorMessage = '';
            //create formdata
            let formData = new FormData();
            formData.append('email/username', this.registerModel.username);
            formData.append('password', this.registerModel.password);
            formData.append('password', this.registerModel.repeatPassword);
            formData.append('firstName', this.registerModel.firstName);
            formData.append('lastName', this.registerModel.lastName);
            formData.append('city', this.registerModel.city);
            formData.append('addressLine', this.registerModel.addressLine);
            formData.append('postalCode', this.registerModel.postalCode);
            formData.append('dateOfBirth', this.registerModel.dateOfBirth);
            await axios.post(this.apiUrl, this.registerModel)
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
                this.userMessage = 'Registered!';
                this.registerModel.username = '';
                this.registerModel.password = '';
                this.registerModel.repeatPassword ='';
                this.registerModel.firstName = '';
                this.registerModel.lastName= '';
                this.registerModel.city='';
                this.registerModel.addressLine='';
                this.registerModel.postalCode='';
                this.registerModel.dateOfBirth='';
                localStorage.setItem('token', `Bearer ${token}`);
            }
        }
    }
});