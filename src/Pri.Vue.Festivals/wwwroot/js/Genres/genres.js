let app = new Vue({
    el: '#app',
    data: {
        pageTitle: 'Genres',
        genres: '',
        error: false,
        errorMessage : '',
        genresLoaded: false,
        genresApiUrl: 'https://localhost:44318/api/Genres'
    },
    created: async function () {
        this.genres = await this.getData(this.genresApiUrl)
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
                    this.genresLoaded = true;
                });
            if (this.error !== true) {
                return response.data;
            }
        }
    },
});