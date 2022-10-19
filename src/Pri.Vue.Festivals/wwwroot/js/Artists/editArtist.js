let app = new Vue({
    el: '#app',
    data: {
        pageTitle: 'Edit artist',
        artistModel: {
            id: '',
            name: '',
            genreId: '',
            checkedFestivals: [],
        },
        token: '',
        genres: '',
        festivals: '',
        error: false,
        userMessage: '',
        success: false,
        apiUrl: 'https://localhost:44318/api/Artists',
        image: '',
    },
    created: async function () {
        //get the token
        this.token = localStorage.getItem('token');
        if (this.token === null) {
            window.location.href = '/account';
        }
        //create the header
        const headers = {
            headers: {
                Authorization: this.token
            },
        };
        this.festivals = await axios.get('https://localhost:44318/api/Festivals', headers)//headers nog wegdoen
            .then(response => response.data)
            .catch(error => { this.error = true; this.userMessage = error })
        this.genres = await axios.get('https://localhost:44318/api/Genres', headers)
            .then(response => response.data)
            .catch(error => { this.error = true; this.userMessage = error })
    },
    methods: {
        addArtist: async function () {
            this.error = false;
            this.success = false;
            this.userMessage = '';
            let errorMessage = '';
            //create the formdata
            let formData = new FormData();
            //add the Model props to formdata
            formData.append('id', this.artistModel.id);
            formData.append('name', this.artistModel.name);
            formData.append('genreId', this.artistModel.genreId);
            this.artistModel.checkedFestivals.forEach(p => {
                formData.append('festivals', p);
            });

            //get the image
            this.image = this.$refs.image.files[0];
            //add formData
            formData.append('image', this.image); //image veranderen werkt nog niet , to-do
            //create the header
            const headers = {
                headers: {
                    Authorization: this.token
                },
            };
            //call axios.post
            let response = await axios.put(this.apiUrl, formData, headers)
                .then(response => response)
                .catch(error => { errorMessage = error; this.error = true })
                .finally(() => { });
            if (this.error === true) {
                this.userMessage = errorMessage;
            }
            else {
                this.success = true;
                this.userMessage = 'artist edited!';
            }
        }
    }
});