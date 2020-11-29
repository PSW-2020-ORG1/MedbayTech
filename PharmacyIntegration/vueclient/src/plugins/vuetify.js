import Vue from 'vue';
import Vuetify, { colors }  from 'vuetify/lib';

Vue.use(Vuetify);

export default new Vuetify({
    theme: {
        themes: {
            light: {
                primary: colors.indigo.base,
                secondary: colors.indigo.lighten4,
                accent: colors.deepOrange.base,
            },
        },
    },
});
