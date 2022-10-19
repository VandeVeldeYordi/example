let app = new Vue({
    el: '#app',
    data: {
        pageTitle: 'Festivals',
        error: false,
        success:false,
        errorMessage: '',
        userMessage: '',
        festivals: '',
        festivalsApiUrl: 'https://localhost:44318/api/Festivals',
        festivalDeleted: false,
        festivalsLoaded: false,
        token: '',
        showFestival: true,
        checkBoxFestival: {
            checkedTickets: [],
            checkedArtists: [],
        },
        festival: { name: '', id:'' , description: '' , locationId:'', organizerId:'' , startDate:'' ,artists:'' ,  endDate:'' ,image:'' , location: '' },
        isReadOnly: true,
        artists: '',
        tickets: '',
        locations: '',
        organizers: '',

    },
    created: async function () {
        this.festivals = await this.getData(this.festivalsApiUrl),
        this.token = localStorage.getItem('token');
        this.artists = await this.getData('https://localhost:44318/api/Artists');
        this.tickets = await this.getData('https://localhost:44318/api/Tickets');
        this.locations = await this.getData('https://localhost:44318/api/Locations');
        this.organizers = await this.getData('https://localhost:44318/api/Organizers');
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
                .finally(() => { this.festivalsLoaded = true; });
            if (this.error !== true) {
                return response.data;
            }
        },
        getDetails: function (festivalDetail) {
            this.showFestival = false;
            axios.get('https://localhost:44318/api/Festivals/' + festivalDetail.id)
                .then(response => (this.festival = response.data , this.festival.image = festivalDetail.image ,this.festival.artists = response.data.artists , this.festival.id = festivalDetail.id));
            console.log(festivalDetail.id);
        },
        returnList: function () {
            this.showFestival = true;
        },
        editFestival: function (isEditMode) {
            if (this.token === null) {
                window.location.href = '/account';
            }
            var self = this;
            self.isReadOnly = false;
            self.isEditMode = isEditMode;          
        },
        saveFestival: async function () { // checkboxen worden nog niet aangeduid bij edit! todo
            this.error = false;
            this.success = false;
            this.userMessage = '';
            let errorMessage = '';
            //create the formdata
            let formData = new FormData();
            //add the Model props to formdata
            formData.append('id', this.festival.id);
            formData.append('name', this.festival.name);
            formData.append('locationId', this.festival.locationId);
            formData.append('organizerId', this.festival.organizerId);
            formData.append('description', this.festival.description);
            this.checkBoxFestival.checkedArtists.forEach(p => {
                formData.append('artists', p);
            });
            this.checkBoxFestival.checkedTickets.forEach(p => {
                formData.append('tickets', p);
            });

            //get the image
            this.image = this.$refs.image.files[0];
            //add formData
            formData.append('image', this.image); 
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
            let response = await axios.put(this.festivalsApiUrl, formData, headers)
                .then(response => response)
                .catch(error => { errorMessage = error; this.error = true })
                .finally(() => { });
            if (this.error === true) {
                this.userMessage = errorMessage;
            }
            else {
                window.location.href = '/festivals';
                this.success = true;
                this.userMessage = 'festival edited!';
            }
        },
        deleteFestival: async function (e) {        
            if (this.token === null) {
                window.location.href = '/account';
            }
            this.festivalDeleted = false;
            let deleteUrl = 'https://localhost:44318/api/Festivals';
            let config = {
                headers: {
                    Authorization: this.token
                },
                params: {
                    id: e.currentTarget.id
                }
            }// axios.delete , header in config   
            await axios.delete(deleteUrl, config).then(response => response).catch(error => console.log(error))
                .finally(() => this.festivalDeleted = true);
            window.location.reload()
        }
    },
});