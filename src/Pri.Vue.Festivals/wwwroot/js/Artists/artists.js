let app = new Vue({
    el: '#app',
    data: {
        pageTitle: 'Artists',
        genres: '',
        error: false,
        success: false,
        errorMessage: '',
        artists: '',
        token: '',
        userMessage: '',
        genresLoaded: false,
        genresApiUrl: 'https://localhost:44318/api/Genres',
        artistsApiUrl: 'https://localhost:44318/api/Artists/genre/',
        artistDeleted: false,
        selectedGenre: '',
        showArtists: true,
        festivals: '',
        artist: { name: '', genreId: '', id: '', image: '', festivals: '' , checkedFestivals:[] },      
        isReadOnly: true,
        apiUrl: 'https://localhost:44318/api/Artists/',
        image:'',
    },
    created: async function () {
          this.token = localStorage.getItem('token');
     
        axios.get('https://localhost:44318/api/Artists/')
            .then(response => (this.artists = response.data));
        this.genres = await this.getData(this.genresApiUrl);
        this.getArtists();
        this.festivals = await axios.get('https://localhost:44318/api/Festivals')
            .then(response => response.data)
            .catch(error => { this.error = true; this.userMessage = error })
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
                .finally(() => { this.genresLoaded = true; });
            if (this.error !== true) {
                return response.data;
            }
            else {
                window.location.href = '/account';
            }
        },
        getArtists: async function (e) {
            if (e === undefined) {
                this.selectedGenre = 1;
            }
            else if (e.currentTarget !== undefined) {
                this.selectedGenre = e.currentTarget.value;
            }
            else {
                this.selectedGenre = e.value;
            }
            let apiUrl = `${this.artistsApiUrl}${this.selectedGenre}`;
            let response = await this.getData(apiUrl);
            this.artists = response;
        },
        getDetails: function (artistDetail) {
           this.showArtists = false;
            axios.get('https://localhost:44318/api/Artists/' + artistDetail.id)
                .then(response => (this.artist.id = artistDetail.id, this.artist, genreId = response.data.genreId,
                    this.artist.name = response.data.name, this.artist.festivals = response.data.festivals, this.artist.image = artistDetail.image));
            console.log(artistDetail.id);
        },
        returnList: function () {
            this.showArtists = true;
        },
        editArtist: function (isEditMode) {
            if (this.token === null) {
                window.location.href = '/account';
            }
            var self = this;
            self.isReadOnly = false;
            self.isEditMode = isEditMode;
            
        },    
            saveArtist: async function () {
                this.error = false;
                this.success = false;
                this.userMessage = '';
                let errorMessage = '';
                //create the formdata
                let formData = new FormData();
                //add the Model props to formdata
                formData.append('id', this.artist.id);
                formData.append('name', this.artist.name);
                formData.append('genreId', this.artist.genreId);
                this.artist.checkedFestivals.forEach(p => {
                    formData.append('festivals', p);
                });


                //get the image
                this.image = this.$refs.image.files[0];
                //add formData
                formData.append('image', this.image); //image veranderen werkt nog niet , to-do , vast in cache?
                //create the header
                const headers = {
                    headers: {
                        Authorization: this.token
                    },
                };
                if (this.token === null) {
                    window.location.href = '/account';
                }
                //call axios.post
                let response = await axios.put(this.apiUrl, formData, headers)
                    .then(response => response)
                    .catch(error => { errorMessage = error; this.error = true })
                    .finally(() => { });
                if (this.error === true) {
                    this.userMessage = errorMessage;
                }
                else {
                    window.location.href = '/artists';
                    this.success = true;
                    this.userMessage = 'artist edited!';
                }
            },
        deleteArtist: async function (e) {
            if (this.token === null) {
                window.location.href = '/account';
            }
            this.artistDeleted = false;
            let deleteUrl = 'https://localhost:44318/api/Artists';
            let config = {
                headers: {
                    Authorization:this.token
                },
                params: { 
                    id: e.currentTarget.id                  
    }
            }// axios.delete , header in config   
            await axios.delete(deleteUrl, config).then(response => response).catch(error => console.log(error))
                .finally(() => this.artistDeleted = true);        
            this.getArtists(this.$refs.slcGenres);
        }
    },
});
///delete button enkel tonen als authorized true is - to do!!