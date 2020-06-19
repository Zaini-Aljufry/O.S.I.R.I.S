# Object Detection and Classification Configuration Guide

### Required packages/libraries
---
- labelImg 
- XML to CSV Converter
- Object Detection API
- Pre-trained Model
- Tensorflow/Keras
- OpenCV
---

### Model Training Pipeline
---
1. Collect relevant images. The more the better
2. Annotate/label image 
3. Split data into test/train samples
4. Generate TF Records from these splits
5. Setup a .config gile for model
6. Train
7. Export graph from a new trained model
---


### References
---
- [The whole guide process](https://pythonprogramming.net/custom-objects-tracking-tensorflow-object-detection-api-tutorial/)
- [Tensorflow's API library](https://github.com/tensorflow/models/tree/master/research/object_detection)
- [Pretrained model library](https://github.com/tensorflow/models/blob/master/research/object_detection/g3doc/detection_model_zoo.md)
- [Labelling and XML-to-CSV Converter tool](https://github.com/datitran/raccoon_dataset)
---



