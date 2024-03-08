<script setup>
import { ref, onMounted, onBeforeMount } from 'vue';
import VehicleService from '@/service/VehicleService';
import CityService from '@/service/CityService';

const dataviewValue = ref(null);
const cities = ref(null);
const selectedCity = ref();
const selectedCityD = ref();
const layout = ref('grid');
const sortKey = ref(null);
const sortOrder = ref(null);
const sortField = ref(null);
const sortOptions = ref([
    { label: 'Precio mayor a menor', value: '!rentalPrice' },
    { label: 'Precio menor a mayor', value: 'rentalPrice' }
]);

const vehicleService = new VehicleService();
const cityService = new CityService();

onBeforeMount(async () => {
    cities.value = await cityService.getCities();
    dataviewValue.value = await vehicleService.getVehicles();
});

const onSortChange = (event) => {
    const value = event.value.value;
    const sortValue = event.value;

    if (value.indexOf('!') === 0) {
        sortOrder.value = -1;
        sortField.value = value.substring(1, value.length);
        sortKey.value = sortValue;
    } else {
        sortOrder.value = 1;
        sortField.value = value;
        sortKey.value = sortValue;
    }
};

const searchVehicles = async() => {

    if (selectedCity.value == undefined){
        dataviewValue.value = await vehicleService.getVehicles();
    }else{
        dataviewValue.value = await vehicleService.getVehiclesByCity(selectedCity.value.id);
    }
};

const getSeverity = (product) => {
    switch (product.idState) {
        case 1:
            return 'success';

        case 2:
            return 'danger';

        case 3:
            return 'warning';


        default:
            return null;
    }
};

const getEstado = (id) => {
    switch (id) {
        case 1:
            return 'DISPONIBLE';

        case 2:
            return 'RENTADO';

        case 3:
            return 'RESERVADO';


        default:
            return null;
    }
};

const getCity = (idCity) => {
    return cities.value.find(x => x.id == idCity).name;
};

</script>

<template>
    <div class="grid">
        <div class="col-12">
            <div class="card">
                <h5>Consultar Vehiculos Disponibles</h5>
                <Toolbar class="mb-4">
                    <template v-slot:start>
                        <div class="my-2">
                            <Dropdown v-model="selectedCity" showClear :options="cities" optionLabel="name" placeholder="Ciudad de recogida" class="w-full md:w-30rem mr-5 ml-3" />
                            <Dropdown v-model="selectedCityD" showClear :options="cities" optionLabel="name" placeholder="Ciudad de devolución" class="w-full md:w-30rem ml-5" />
                        </div>
                    </template>

                    <template v-slot:end>
                        <Button label="Buscar!" icon="pi pi-search" raised  @click="searchVehicles()" />
                    </template>
                </Toolbar>

                
                <DataView :value="dataviewValue" :layout="layout" :paginator="true" :rows="9" :sortOrder="sortOrder"
                    :sortField="sortField">
                    <template #header>
                        <div class="grid grid-nogutter">
                            <div class="col-6 text-left">
                                <Dropdown v-model="sortKey" :options="sortOptions" optionLabel="label"
                                    placeholder="Ordenar por precio" @change="onSortChange($event)" />
                            </div>
                            <div class="col-6 text-right">
                                <DataViewLayoutOptions v-model="layout" />
                            </div>
                        </div>
                    </template>

                    <template #list="slotProps">
                        <div class="grid grid-nogutter">
                            <div v-for="(item, index) in slotProps.items" :key="index" class="col-12">
                                <div class="flex flex-column sm:flex-row sm:align-items-center p-4 gap-3"
                                    :class="{ 'border-top-1 surface-border': index !== 0 }">
                                    <div class="md:w-10rem relative">
                                        <img class="block xl:block mx-auto border-round w-full"
                                            :src="`src/assets/vehicles/${item.plate}.jpg`"
                                            :alt="item.name" />
                                        <Tag :value="getEstado(item.idState)" :severity="getSeverity(item)"
                                            class="absolute" style="left: 4px; top: 4px"></Tag>
                                    </div>
                                    <div
                                        class="flex flex-column md:flex-row justify-content-between md:align-items-center flex-1 gap-4">
                                        <div
                                            class="flex flex-row md:flex-column justify-content-between align-items-start gap-2">
                                            <div>
                                                <span class="font-medium text-secondary text-sm">{{ item.model
                                                    }}</span>
                                                <div class="text-lg font-medium text-900 mt-2">{{ item.brand }}</div>
                                            </div>
                                            <div class="surface-100 p-1" style="border-radius: 30px">
                                                <div class="surface-0 flex align-items-center gap-2 justify-content-center py-1 px-2"
                                                    style="border-radius: 30px; box-shadow: 0px 1px 2px 0px rgba(0, 0, 0, 0.04), 0px 1px 2px 0px rgba(0, 0, 0, 0.06)">
                                                    <span class="text-900 font-medium text-sm">{{ getCity(item.idCity) }}</span>
                                                    <i class="pi pi-map-marker text-yellow-500"></i>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="flex flex-column md:align-items-end gap-5">
                                            <span class="text-xl font-semibold text-900">${{ item.rentalPrice }}</span>
                                            <div class="flex flex-row-reverse md:flex-row gap-2">
                                                <Button icon="pi pi-heart" severity="danger" outlined raised ></Button>
                                                <Button icon="pi pi-shopping-cart" label="Reservar!"  severity="success" outlined raised 
                                                    :disabled="item.idState === '2'"
                                                    class="flex-auto md:flex-initial white-space-nowrap"></Button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </template>

                    <template #grid="slotProps">
                        <div class="grid grid-nogutter">
                            <div v-for="(item, index) in slotProps.items" :key="index"
                                class="col-12 sm:col-6 md:col-4 p-2 ">
                                <div class="p-4 border-1 surface-border surface-card border-round flex flex-column">
                                    <div class="surface-50 flex justify-content-center border-round p-3">
                                        <div class="relative mx-auto">
                                            <img class="border-round"
                                                :src="`src/assets/vehicles/${item.plate}.jpg`"
                                                :alt="item.name" style="width: 300px; height: 300px;" />
                                            <Tag :value="getEstado(item.idState)" :severity="getSeverity(item)"
                                                class="absolute" style="left: 4px; top: 4px"></Tag>
                                        </div>
                                    </div>
                                    <div class="pt-4">
                                        <div class="flex flex-row justify-content-between align-items-start gap-2">
                                            <div>
                                                <span class="font-medium text-secondary text-sm">{{ item.model
                                                    }}</span>
                                                <div class="text-lg font-medium text-900 mt-1">{{ item.brand }}</div>
                                            </div>
                                            <div class="surface-100 p-1" style="border-radius: 30px">
                                                <div class="surface-0 flex align-items-center gap-2 justify-content-center py-1 px-2"
                                                    style="border-radius: 30px; box-shadow: 0px 1px 2px 0px rgba(0, 0, 0, 0.04), 0px 1px 2px 0px rgba(0, 0, 0, 0.06)">
                                                    <span class="text-900 font-medium text-sm">{{ getCity(item.idCity) }}</span>
                                                    <i class="pi pi-map-marker text-yellow-500"></i>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="flex flex-column gap-4 mt-4">
                                            <span class="text-2xl font-semibold text-900">${{ item.rentalPrice }}</span>
                                            <div class="flex gap-2">
                                                <Button icon="pi pi-shopping-cart" label="Reservar!" severity="success" outlined raised 
                                                    :disabled="item.idState === '2'"
                                                    class="flex-auto white-space-nowrap"></Button>
                                                <Button icon="pi pi-heart" severity="danger" outlined raised></Button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </template>
                </DataView>
            </div>
        </div>
    </div>
</template>
