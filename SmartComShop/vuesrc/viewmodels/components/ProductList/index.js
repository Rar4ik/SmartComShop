import Vue from 'vue'
import Product from './Product.vue';
import Axios from 'axios';

new Vue({
    data() {
        return {
            localData: [],
            isScrolled: false,
        };
    },
    components: {
        listProduct: Product,
    },
    mounted() {
        Axios
        .get('/Get')
        .then(response => (this.localData = response.data))
        window.addEventListener(
            "scroll",
            () => (this.isScrolled = window.scrollY > 10)
        );
    },
})