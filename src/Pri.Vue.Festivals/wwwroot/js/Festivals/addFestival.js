let app = new Vue({
    el: '#app',
    data: {
        pageTitle: 'Add new Festival',
        festivalModel: {
            name: '',
            description: '',
            locationId: '',
            organizerId: '',
            checkedTickets: [],
            checkedArtists: [],
        },
        token: '',
        artists: '',
        organizers: '',
        tickets: '',
        locations: '' ,
        error: false,
        userMessage: '',
        success: false,
        apiUrl: 'https://localhost:44318/api/Festivals',
        image: '',
    },
    created: async function () {
        //get the token
        this.token = localStorage.getItem('token');
        if (this.token === null) {
            window.location.href = '/account';
        };
        ////create the header
        //const headers = {
        //    headers: {
        //        Authorization: this.token
        //    },
        //};
        this.artists = await axios.get('https://localhost:44318/api/Artists')
            .then(response => response.data)
            .catch(error => { this.error = true; this.userMessage = error });
        this.tickets = await axios.get('https://localhost:44318/api/Tickets')
            .then(response => response.data)
            .catch(error => { this.error = true; this.userMessage = error });
        this.locations = await axios.get('https://localhost:44318/api/Locations')
            .then(response => response.data)
            .catch(error => { this.error = true; this.userMessage = error });
        this.organizers = await axios.get('https://localhost:44318/api/Organizers')
            .then(response => response.data)
            .catch(error => { this.error = true; this.userMessage = error });
    },
    methods: {
        addFestival: async function () {
            this.error = false;
            this.success = false;
            this.userMessage = '';
            let errorMessage = '';
            //create the formdata
            let formData = new FormData();
            //add the Model props to formdata
            formData.append('name', this.festivalModel.name);
            formData.append('description', this.festivalModel.description);
            formData.append('locationId', this.festivalModel.locationId);
            formData.append('organizerId', this.festivalModel.organizerId);
            this.festivalModel.checkedTickets.forEach(p => {
                formData.append('tickets', p);
            });
            this.festivalModel.checkedArtists.forEach(p => {
                formData.append('artists', p);
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
            //call axios.post
            let response = await axios.post(this.apiUrl, formData, headers)
                .then(response => response)
                .catch(error => { errorMessage = error; this.error = true })
                .finally(() => { });
            if (this.error === true) {
                this.userMessage = errorMessage;
            }
            else {
                this.success = true;
                this.userMessage = 'festival added!';
            }
        }
    }
});