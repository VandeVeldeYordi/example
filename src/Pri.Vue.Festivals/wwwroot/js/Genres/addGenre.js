let app = new Vue({
    el: '#app',
    data: {
        pageTitle: 'Add a new genre',
        genreModel: {
            name: '',
            description: '',
        },
        token: '',
        error: false,
        userMessage: '',
        success: false,
        apiUrl: 'https://localhost:44318/api/Genres',
    },
    created: async function () {
        //get the token
        this.token = localStorage.getItem('token');
        if (this.token === null) {
            window.location.href = '/account';
        }       
    },
    methods: {
        addGenre: async function () {
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
            let response = await axios.post(this.apiUrl,this.genreModel , headers)
                .then(response => response.data)
                .catch(error => { errorMessage = error; this.error = true })
                .finally(() => { });
            if (this.error === true) {
                this.userMessage = errorMessage.response.data;
            }
            else {
                this.success = true;
                this.userMessage = 'genre added!';
            }
        }
    }
});