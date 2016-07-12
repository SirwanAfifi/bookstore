import urllib2 as ulb
from PIL import Image as img
import scipy as sp
from scipy.misc import imread as imgRead
from scipy.signal.signaltools import correlate2d as c2d
import numpy
import io
import os
from array import array
from operator import itemgetter

class GetImage(object):
    def get_image(self):
            try:
                self.url_input=raw_input("Enter the url:")
                """request_url = ulb.Request(self.url_input, headers={'User-Agent' : "Magic Browser"})"""
                f = open(self.url_input)
                image_data= f.read()
                self.image_file= image_data;
            except:
                print "\nAn error ocured. Please retry!\n"
    def get_image_file(self, filePath):
            try:
                self.url_input = filePath
                f = open(self.url_input)
                image_data= f.read()
                self.image_file= image_data;
            except:
                print "\nAn error ocured. Please retry!\n"

    def scale_image(self):
        try:
            image=img.open(self.url_input)
            is_notjpg=self.is_ext_notjpg()
            if is_notjpg:
                image=self.convert_to_jpg(image)
            image=image.resize((100, 100), img.ANTIALIAS)
            return image
        except:
            print "\nImage data corrupted! please retry!\n"
            exit()

    def is_ext_notjpg(self):
        if self.url_input.endswith(('.png', '.gif', '.tiff', '.bmp', '.gif')):
            return True
        return False

    def is_not_an_image(self):
        if self.url_input.endswith(('.png', '.gif', '.tiff', '.bmp', '.gif', '.jpg')):
            return False
        return True

    def convert_to_jpg(self, old_image):
        new_image = img.new("RGB", old_image.size, (255,255,255))
        new_image.paste(old_image,(0,0), old_image)
        new_image.save("temp.jpg", "JPEG")
        new_image = img.open("temp.jpg")
        return new_image






my_array = []
class CompareImage(object):
    def __init__(self):
        print "\ncomparing images\n"
        

    def get_data(self, str_name):
        try:
            self.image_data=numpy.array(str_name)
            self.image_data=sp.inner(self.image_data, [299, 587, 114])/1000.0
            std_deviation=self.image_data.std()
            if std_deviation==0.0:
                print "\nImage error! Please retry!\n"
                exit()
            return ((self.image_data-self.image_data.mean())/std_deviation)
        except:
            print "\nAwwh, somethings not right! Try again\n"
            exit()

    def correlate_image(self, image_one, image_two, filename):
        try:
            max_range=c2d(image_one, image_one, mode='same')
            img_result=c2d(image_one, image_two, mode='same')
            result_final=((img_result.max()/max_range.max())*100)
            my_array.append({'name': filename, 'number': result_final})
            print "with: " + filename + " | Images are", result_final,"percent similar\n"
            if result_final==100.0:
                print "with: " + filename + " | Images are exactly same\n"
            elif result_final==0.0:
                print "with: " + filename + " | Images are very different\n"
        except:
            print "\nAwwh, somethings not right! Try again\n"
            exit()


def main():
    imge = CompareImage()
    img_one = GetImage()
    img_one.get_image()
    pic1=img_one.scale_image()
    image1=imge.get_data(pic1)
    

    for filename in os.listdir("C:\\Users\\Public\\Pictures\Sample Pictures"):
        file = os.path.join("C:\\Users\\Public\\Pictures\Sample Pictures", filename)
        img_two = GetImage()
        img_two.get_image_file(file)
        pic2 = img_two.scale_image()
        image2 = imge.get_data(pic2)
        imge.correlate_image(image1, image2, filename)

    
    
    max_item = max(my_array, key=itemgetter('number'))
    min_item = min(my_array, key=itemgetter('number'))

    print '===============================Result===============================\n'
    
    print 'Most similar: {0}, with percent: {1}\n'.format(max_item['name'], max_item['number'])
    print 'Least similar: {0}, with percent: {1}'.format(min_item['name'], min_item['number'])

    print '\n===================================================================='


    

if __name__ == "__main__":
    main()
