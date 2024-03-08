export default class CityService {
    async getCities() {
        var data = await fetch('https://localhost:7029/City')
            .then(
                function (response) {
                    if (response.status !== 200) {
                        console.log('Ocurrio un error al consultar: ' +
                            response.status);
                        return;
                    }

                    return response.json();
                }
            )
            .catch(function (err) {
                console.log('Fetch Error :-S', err);
            });
        return data;
    }
}
