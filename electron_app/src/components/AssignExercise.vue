<template>
  <b-container>
    <b-row> Huidige Exercises van client </b-row>
    <b-row>
      <b-list-group style="width: 100%">
        <b-list-group-item
          v-for="ce in client.clientExercises"
          :key="ce.clientExerciseId"
        >
          <b-row>
            <b-col sm="6"> {{ ce.exercise.name }} </b-col>
            <b-col sm="4">
              {{ ce.weeklyRepetitionsCompleted }}/{{ ce.weeklyRepetitions }}
              afgerond
            </b-col>
            <b-col sm="2">
              <b-button v-b-modal.delete-warn-modal variant="danger">
                <b-icon icon="trash" />
              </b-button>
              <b-modal id="delete-warn-modal" title="Waarschuwing!">
                <p class="my-4">
                  Weet u zeker dat u {{ ce.exercise.name }} wilt verwijderen van
                  {{ client.userName }}?
                </p>
                <p class="my-4">
                  {{ client.userName }} zal alle voortgang in de oefening
                  kwijtraken
                </p>
                <template #modal-footer>
                  <b-row>
                    <b-button>Annuleren</b-button>
                    <b-button variant="danger" @click="removeClientExercise(ce.clientExerciseId)">Oefening verwijderen</b-button>
                  </b-row>
                </template>
              </b-modal>
            </b-col>
          </b-row>
        </b-list-group-item>
      </b-list-group>
    </b-row>
    <hr />
    <b-row>
      <p>Nieuwe oefening toewijzen</p>
      <b-input-group>
        <template #append>
          <b-input-group-text>
            <b-icon icon="search" />
          </b-input-group-text>
        </template>
        <b-form-input
          v-model="query"
          placeholder="Zoek op oefening naam of beschrijving..."
        ></b-form-input>
      </b-input-group>
      <b-list-group
        v-if="allExercises !== undefined"
        style="overflow-y: scroll; max-height: 60vh; width: 100%"
      >
        <b-list-group-item
          button
          v-for="(ex, index) in matchingExercises"
          :key="ex.id"
          @click="setActive(index)"
        >
          <b-row class="text-center">
            <b-col sm="10">
              {{ ex.name }}
            </b-col>
            <b-col>
              <b-icon v-if="activeIndex === index" icon="caret-left" />
              <b-icon v-else icon="caret-down" />
            </b-col>
          </b-row>
          <div v-if="activeIndex === index">
            <hr />
            <b-card
              :img-src="ex.image_url"
              img-alt="Oefeningsafbeelding"
              img-top
              :shadow="true"
              tag="article"
              class="mb-2 custom-background border-0"
            >
              <b-card-title>
                <div class="d-flex flex-row font-weight-semi-bold">
                  {{ ex.name }}
                </div>
              </b-card-title>
              <b-card-body>
                <p>{{ ex.description }}</p>
                <b-list-group label="poses">
                  <b-list-group-item
                    v-for="(pose, index) in ex.poses"
                    :key="index"
                  >
                    {{ pose }}
                  </b-list-group-item>
                </b-list-group>
              </b-card-body>
              <b-form @submit.prevent="submit(ex)">
                <b-row>
                  <b-col sm="9">
                    Aantal wekelijkse herhalingen
                    <b-form-invalid-feedback :state="validateWeeklyRepetitions"
                      >Oefening moet minimaal 1 keer per week uitgevoerd
                      worden</b-form-invalid-feedback
                    >
                  </b-col>

                  <b-col sm="3">
                    <b-form-input
                      type="number"
                      v-model="weeklyRepetitions"
                      required
                      min="1"
                    ></b-form-input>
                  </b-col>
                </b-row>
                <b-row>
                  <b-col sm="6">
                    Einddatum
                    <b-form-invalid-feedback :state="validatefinishingDate"
                      >Vul een einddatum in</b-form-invalid-feedback
                    >
                  </b-col>
                  <b-col sm="6">
                    <b-form-datepicker
                      required
                      v-model="finishingDate"
                      :min="minDate"
                      class="mb-2"
                    ></b-form-datepicker>
                  </b-col>
                </b-row>
                <div class="d-flex flex-row-reverse">
                  <b-button type="submit" variant="primary">
                    <div v-if="!submitting">Oefening toewijzen</div>
                    <pulse-loader v-else :color="'#FFFFFF'"></pulse-loader>
                  </b-button>
                </div>
              </b-form>
            </b-card>
          </div>
        </b-list-group-item>
      </b-list-group>
      <b-col v-else class="mx-auto text-center">
        <br />
        <pulse-loader :color="'#FFFFFF'"></pulse-loader>
      </b-col>
    </b-row>
  </b-container>
</template>
<script>
import PulseLoader from "vue-spinner/src/PulseLoader.vue";
export default {
  components: {
    PulseLoader,
  },
  props: {
    clientProp: Object,
  },
  computed: {
    validateWeeklyRepetitions() {
      return this.weeklyRepetitions > 0;
    },
    validatefinishingDate() {
      return this.finishingDate !== undefined;
    },
    allExercises() {
      return this.$store.getters["exercises/get_all_exercises"];
    },
    matchingExercises() {
      return this.allExercises.filter((exercise) => {
        return (
          exercise.name.toLowerCase().includes(this.query.toLowerCase()) ||
          exercise.description.toLowerCase().includes(this.query.toLowerCase())
        );
      });
    },
  },
  data() {
    const now = new Date();
    const today = new Date(now.getFullYear(), now.getMonth(), now.getDate());
    return {
      client: this.clientProp,
      minDate: today,
      submitting: false,
      query: "",
      activeIndex: undefined,
      weeklyRepetitions: 1,
      finishingDate: undefined,
    };
  },
  methods: {
    setActive(index) {
      this.activeIndex = index;
    },
    submit(exercise) {
      if (this.validateWeeklyRepetitions && this.validatefinishingDate) {
        this.submitting = true;
        this.assign(exercise).then(() => {
          this.submitting = false;
        });
      }
    },
    async assign(exercise) {
      var payload = {
        clientId: this.client.id,
        exerciseId: exercise.exerciseId,
        weeklyRepetitions: this.weeklyRepetitions,
        finishingDate: this.finishingDate,
      };
      console.log(payload);
      await this.$store.dispatch("therapist/assignExercise", payload);
      await this.refreshClient();
    },
    async removeClientExercise(clientExerciseId) {
      await this.$store.dispatch(
        "therapist/removeClientExercise",
        clientExerciseId
      );
      await this.refreshClient();
    },
    async refreshClient() {
      this.$store.dispatch("therapist/getTherapist").then(() => {
        this.client = this.$store.getters[
          "therapist/get_therapist"
        ].clients.find((client) => client.id == this.client.id);
      });
    },
  },
};
</script>
