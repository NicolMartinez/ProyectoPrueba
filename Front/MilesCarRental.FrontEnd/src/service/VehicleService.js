export default class VehicleService {
    async getVehicles() {
        var data = await fetch('https://localhost:7029/Vehicle')
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

    async getVehiclesByCity(idCity) {
        var data = await fetch('https://localhost:7029/Vehicle/GetByCity/' + idCity)
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
