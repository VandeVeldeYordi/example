let app = new Vue({
    el: '#app',
    data: {
        pageTitle: 'Festival locations',
        locations: '',
        error: false,
        errorMessage: '',
        locationsLoaded: false,
        locationsApiUrl: 'https://localhost:44318/api/Locations'
    },
    created: async function () {
        this.locations = await this.getData(this.locationsApiUrl)
    },
    methods: {
        getData: async function (apiUrl) {
            let response = '';
            response = await axios.get(apiUrl)
                .then(response => response)
                .catch(error => {
                    this.error = true;
                    this.errorMessage = error;
                })
                .finally(() => {
                    this.locationsLoaded = true;
                });
            if (this.error !== true) {
                return response.data;
            }
        }
    },
});