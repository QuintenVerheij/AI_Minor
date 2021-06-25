<template>
  <body>
    <b-container>
      <b-row>
        <b-col sm="8">
          <b-list-group class="client-list">
            <b-list-group-item class="font-weight-semi-bold">
              <b-row>
                <b-col sm="3">Gebruikersnaam</b-col>
                <b-col sm="5">E-mail</b-col>
                <b-col sm="4">Telefoon</b-col>
              </b-row>
            </b-list-group-item>
            <b-list-group-item
              class="text-dark client-list-item"
              :class="{ active: activeIndex === index }"
              v-for="(client, index) in therapist.clients"
              v-bind:key="client.id"
              @click="setActive(client, index)"
            >
              <b-row>
                <b-col sm="3">{{ client.userName }}</b-col>
                <b-col sm="5">{{ client.email }}</b-col>
                <b-col sm="4">{{ client.phoneNumber }}</b-col>
              </b-row>
              <div v-if="activeIndex === index">
                <b-row style="height: fit-content">
                  <b-col sm="8">
                    <arrow-carousel>
                      <rl-carousel-slide
                        v-for="(value, name) in lastWeekResult"
                        :key="name"
                      >
                        <div>
                          <h2 class="text-center">{{ name }}</h2>
                          <excercise-chart
                            :dataSet="value"
                            :options="chartOptions"
                            :chartColors="positiveChartColors"
                            label="Positive"
                          />
                        </div>
                      </rl-carousel-slide>
                    </arrow-carousel>
                  </b-col>
                </b-row>
              </div>
            </b-list-group-item>
          </b-list-group>
        </b-col>
        <b-col sm="4">
          <b-container>
            <b-card
              width="500"
              :img-src="therapist.file"
              img-alt="Image"
              img-top
              :shadow="true"
              tag="article"
              style="min-width: 18rem"
              class="mb-2 custom-background border-0"
            >
              <b-card-title>
                <div class="d-flex flex-row font-weight-semi-bold">
                  Uw pairing code: {{ therapist.pairingCode.code }}
                </div>
              </b-card-title>
              <b-card-body>
                <b-row>{{ therapist.userName }}</b-row>
                <b-row>{{ therapist.email }}</b-row>
                <b-row>{{ therapist.phoneNumber }}</b-row>
              </b-card-body>
            </b-card>
          </b-container>
        </b-col>
      </b-row>
    </b-container>
  </body>
</template>
<script>
import ExcerciseChart from "../components/ExcerciseChart.vue";
import {RlCarouselSlide } from 'vue-renderless-carousel'
import ArrowCarousel from '../components/ArrowCarousel.vue'
export default {
  components: { ExcerciseChart, ArrowCarousel, RlCarouselSlide },
  props: {
    therapist: Object,
  },
  data() {
    return {
      slide: 0,
      activeIndex: undefined,
      positiveChartColors: {
        borderColor: "#077187",
        pointBorderColor: "#0E1428",
        pointBackgroundColor: "#AFD6AC",
        backgroundColor: "#74A57F",
      },
      chartOptions: {
        responsive: true,
        maintainAspectRatio: false,
      },
    };
  },
  computed: {
    lastWeekResult() {
      return this.$store.getters["exercises/get_last_week_result"];
    },
  },
  methods: {
    setActive(client, index) {
      this.activeIndex = index;
    },
  },
};
</script>
<style scoped>
.client-list {
  border-radius: 5px;
}

.client-list-item {
  background: white;
}
.client-list-item:hover {
  background: lightpink;
}
.card-body {
  min-width: fit-content;
  background-color: white;
  border: 1px solid #f4f4f4;
  border-radius: 5px;
}
</style>