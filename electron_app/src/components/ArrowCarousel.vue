<template>
  <rl-carousel v-model="slide">
    <div slot-scope="{ wrapperStyles, slides: { count, active } }">
      <div class="overflow-hidden text-center">
        <div v-bind="wrapperStyles">
          <slot></slot>
        </div>
      </div>
      <div class="mt-4 text-center">
        <span
          v-for="(item, index) in count"
          :key="index"
          class="mx-1 cursor-pointer"
          @click="slide = index"
        >
          <svg
            xmlns="http://www.w3.org/2000/svg"
            width="50"
            height="30"
            class="stroke-current"
            :class="{
              'text-grey': active !== index,
              'text-grey-dark': active === index,
            }"
          >
            <line
              x1="0"
              y1="15"
              x2="50"
              y2="15"
              :style="{ stroke: slide === index ? 'white' : 'grey' }"
              stroke-width="5"
            />
          </svg>
        </span>
      </div>
    </div>
  </rl-carousel>
</template>

<script>
import { RlCarousel } from "vue-renderless-carousel";
export default {
  name: "arrow-carousel",
  components: {
    RlCarousel,
  },
  data() {
    return {
      slide: 0,
      interval: undefined,
      animateLeft: false,
      animateRight: false
    };
  },
  methods: {
      triggerAnimation (direction) {
      this[`animate${direction}`] = true
    }
  },
};
</script>

<style scoped>
svg {
  transition: color 0.5s ease;
  z-index: 101;
}
.control-chevron {
    transition: font-size .5s ease;
}
.control-chevron.animate-left {
      animation: animate-left 1s;
    }
.control-chevron.animate-right {
      animation: animate-right 1s;
    }

  @keyframes animate-left {
    50% {
      transform: translateX(-10px)
    }
  }
  @keyframes animate-right {
    50% {
      transform: translateX(10px)
    }
  }
</style>