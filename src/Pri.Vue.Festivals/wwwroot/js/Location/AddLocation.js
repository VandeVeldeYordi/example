let app = new Vue({
    el: '#app',
    data: {
        pageTitle: 'add festival locations',
        locationModel: {
            name: '',
            postal: '',
            city: '',
        },
        token: '',
        error: false,
        success:false,
        userMessage:'',
        locationsApiUrl: 'https://localhost:44318/api/Locations'
    },
    created: async function () {
        //get the token
       
        this.token = localStorage.getItem('token');
        if (this.token === null) {
            window.location.href = '/account';
        }
    },
    methods: {
        addLocation: async function () {
            this.error = false;
            this.success = false;
            this.userMessage = '';
            let errorMessage = '';        
         //create the header
            const headers = {
                headers: {
                    Authorization: this.token
                },
            };
            //call axios.post
            let response = await axios.post(this.locationsApiUrl, this.locationModel, headers)
                .then(response => response)
                .catch(error => { errorMessage = error; this.error = true })
                .finally(() => { });
            if (this.error === true) {
                this.userMessage = errorMessage.response.data;
            }
            else {
                this.success = true;
                this.userMessage = 'location added!';
            }            
        }
    },
});